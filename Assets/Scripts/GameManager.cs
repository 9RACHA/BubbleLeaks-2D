using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject bubblePrefab;
    public AudioClip bubbleDestroyedAudio;
    public AudioClip bubbleCollisionAudio;
    public int initialHealth = 10;
    public float spawnProbability = 0.04f;
    public float spawnInterval = 0.1f;
    public Rect spawnArea = new Rect(-4f, -1f, 8f, 4f);

    private int points = 0;
    private int health;
    private AudioSource audioSource;
    private bool gameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        health = initialHealth;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(SpawnBubbles());
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            if (gameOver)
            {
                yield break; // Salir de la corrutina si el juego ha terminado
            }

            yield return new WaitForSeconds(spawnInterval);

            if (Random.value < spawnProbability)
            {
                float randomX = Random.Range(spawnArea.xMin, spawnArea.xMax);
                float randomY = Random.Range(spawnArea.yMin, spawnArea.yMax);
                Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

                if (bubblePrefab != null && bubbleDestroyedAudio != null && bubbleCollisionAudio != null)
                {
                    GameObject bubbleObj = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
                    Bubble bubble = bubbleObj.GetComponent<Bubble>();
                    bubble.bubbleDestroyedAudio = bubbleDestroyedAudio;
                    bubble.bubbleCollisionAudio = bubbleCollisionAudio;
                }
                else
                {
                    Debug.LogWarning("One or more references in GameManager are not assigned.");
                }
            }
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        Debug.Log("Total Points: " + points);
    }

    public void DecreaseHealth()
    {
        health--;
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
        // Add your game over logic here
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
