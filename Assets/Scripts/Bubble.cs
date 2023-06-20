using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    public float growthDuration = 2f;
    public float movementSpeed = 0.8f;
    public float speedChangeInterval = 0.5f;
    public float minHorizontalSpeedChange = -0.1f;
    public float maxHorizontalSpeedChange = 0.1f;
    public float minVerticalSpeedChange = -0.2f;
    public float maxVerticalSpeedChange = 0.1f;

    public AudioClip bubbleDestroyedAudio;
    public AudioClip bubbleCollisionAudio;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isDestroyed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Grow());
        StartCoroutine(ChangeSpeed());
    }

    private IEnumerator Grow()
    {
        animator.SetTrigger("grow");
        yield return new WaitForSeconds(growthDuration);

        Vector2 movementDirection = Random.insideUnitCircle.normalized;
        rb.velocity = movementDirection * movementSpeed;
    }

    private IEnumerator ChangeSpeed()
    {
        while (!isDestroyed)
        {
            yield return new WaitForSeconds(speedChangeInterval);

            Vector2 speedChange = new Vector2(Random.Range(minHorizontalSpeedChange, maxHorizontalSpeedChange),
                                               Random.Range(minVerticalSpeedChange, maxVerticalSpeedChange));
            rb.velocity += speedChange;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mario"))
        {
            GameManager.instance.AddPoints(10);
            GameManager.instance.PlaySound(bubbleDestroyedAudio);
            DestroyBubble();
        }
        else if (collision.gameObject.CompareTag("ScreenBoundary"))
        {
            GameManager.instance.DecreaseHealth();
            GameManager.instance.PlaySound(bubbleCollisionAudio);
            DestroyBubble();
        }
    }

    private void DestroyBubble()
    {
        rb.velocity = Vector2.zero;
        rb.simulated = false;

        animator.SetTrigger("destroy");
        isDestroyed = true;
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}

