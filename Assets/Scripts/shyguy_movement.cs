using System.Runtime.CompilerServices;
using UnityEngine;

public class shyguy_movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedX;
    public float leftX, rightX;
    private int isFacingRight = 1;

    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    private Animator anim_shyguy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_shyguy = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        // allows shy guy to rotate after reaching a certain point
        if (transform.position.x > rightX || transform.position.x < leftX)
        {
            Flip();
        }

        rb.linearVelocity = Vector2.right * isFacingRight * speedX;

    }

    private void Flip() //flips shy guy since npc
    {
        transform.Rotate(0, 180, 0);
        isFacingRight *= -1;
    }

}
