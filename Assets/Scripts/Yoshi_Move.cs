using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi_Move : MonoBehaviour
{
    float speedX;
    public float speed = 5f;
    Rigidbody2D rb;
    private bool isFacingRight = false;
    public float jump = 8f;
   

    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    // animation
    private Animator anim_yoshi;

    // Start is called before the first frame update
    void Start()
    {
        anim_yoshi = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        // Handle horizontal movement
        speedX = Input.GetAxisRaw("Horizontal") * speed;

        // Jump handling
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump); // Jumping without adding force
        }
        
     
        // Apply the velocity (only horizontal movement, vertical is handled by gravity)
        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);

        // Set animations for idle/run
        if (speedX != 0)
        {
            anim_yoshi.SetBool("is_running", true);
        }
        else
        {
            anim_yoshi.SetBool("is_running", false);
        }

        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && speedX > 0f || !isFacingRight && speedX < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
