using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class flyguy_move : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform wayPoint1;
    public Transform wayPoint2;
    private float moveSpeed = 3.0f;

    private Vector3 nextPosition;


    //public Transform inGround;
    //public LayerMask groundLayer;
    //bool isGrounded;

    private Animator anim_flyguy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_flyguy = GetComponent<Animator>();

        nextPosition = wayPoint2.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);

        if (transform.position == nextPosition)
        {
            nextPosition = (nextPosition == wayPoint1.position) ? wayPoint2.position : wayPoint1.position;
        }
    }

   
}
