using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi_Move : MonoBehaviour
{
    float speedX;
    float speedY;
    public float speed;
    Rigidbody2D rb;
    private bool isFacingRight = false;
    public float jump;

    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    // flutter jump variables
    public float flutterJumpForce;
    public float flutterJumpDuration;
    private float flutterJumpTime;
    private bool canDoubleJump = false;

    // animation
    private Animator anim_yoshi;

    // Start is called before the first frame update
    void Start()
    {
        anim_yoshi = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        speedX = Input.GetAxisRaw("Horizontal") * speed;


        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jump)); // regular jump
                canDoubleJump = true;  // enable double jump
            }
            else if (canDoubleJump)
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jump)); // double jump
                canDoubleJump = false;  // disable double jump after use
            }
        }

        // flutter jump (while in air and holding jump)
        if (!isGrounded && !canDoubleJump && flutterJumpTime < flutterJumpDuration)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(new Vector2(0, flutterJumpForce));  // flutter force, how much it increases the height
                flutterJumpTime += Time.deltaTime;
            }
        }
        else
        {
            flutterJumpTime = 0f;  // reset flutter jump time if no longer holding jump
        }


        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);

        //set animations for idle/run
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