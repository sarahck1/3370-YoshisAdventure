using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

public class shyguy_movement : MonoBehaviour
{
    Rigidbody2D rb;
    private float speedX = 1.0f;
    private float rightX = 16.5f;
    private float leftX = 13.6f;
    private int isFacingRight = 1;
    private bool isFlipping;

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
        if (!isFlipping && (transform.position.x >= rightX || transform.position.x <= leftX))
        {
            StartCoroutine(Flip());
        }

        rb.linearVelocity = Vector2.right * isFacingRight * speedX;

    }

    IEnumerator Flip() //flips shy guy since npc
    {
        isFlipping = true;
        transform.Rotate(0, 180, 0);
        isFacingRight *= -1;

        yield return new WaitForSeconds(0.4f);
        isFlipping = false;
    }

}
