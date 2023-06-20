using UnityEngine;

public class Mario : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3.2f;
    public float jumpForce = 6.5f;
    public float airJumpForce = 4f;

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isJumpButtonPressed = Input.GetButtonDown("Jump");

        // Movimiento horizontal
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Cambiar dirección de Mario
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Animaciones
        if (isGrounded)
        {
            if (moveInput != 0)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }

            if (isJumpButtonPressed)
            {
                isJumping = true;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("jumping", true);
            }
            else
            {
                isJumping = false;
                animator.SetBool("jumping", false);
            }
        }
        else
        {
            animator.SetBool("walking", false);
            animator.SetBool("jumping", true);

            if (isJumpButtonPressed && !isJumping)
            {
                isJumping = true;
                rb.AddForce(new Vector2(0f, airJumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detección de si está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Detección de si no está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(Vector3.up, 180f);
    }
}
