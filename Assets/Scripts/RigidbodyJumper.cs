using UnityEngine;
 
public class RigidbodyJumper : MonoBehaviour
{
    public float moveSpeed = 5f;       
    public float jumpForce = 10f;      
 
    public Animator animator;          
 
    private Rigidbody2D rb;
    private bool facingRight = true;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
        if (animator == null)
            animator = GetComponent<Animator>();
    }
 
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); 
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
 
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
 
        WrapAroundScreen();
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && rb.linearVelocity.y <= 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
 
            if (animator != null)
                animator.SetTrigger("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void WrapAroundScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
 
        if (pos.x < 0f)
            pos.x = 1f;
        else if (pos.x > 1f)
            pos.x = 0f;
 
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}