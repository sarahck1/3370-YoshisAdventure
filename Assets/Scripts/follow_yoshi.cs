using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_yoshi : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float fixedY = 0f;

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.Lerp(transform.position.x, target.position.x, FollowSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, fixedY, -10f);
    }
}
