using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_yoshi : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float zOffset = -10f;

    public Vector2 deadZone = new Vector2(1f, 1f);

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 currentPos = transform.position;
            Vector3 targetPos = target.position;

            float xDiff = Mathf.Abs(currentPos.x - targetPos.x);
            float yDiff = Mathf.Abs(currentPos.y - targetPos.y);

            float newX = currentPos.x;
            float newY = currentPos.y;

            if (xDiff > deadZone.x)
            {
                newX = Mathf.Lerp(currentPos.x, targetPos.x, FollowSpeed * Time.deltaTime);
            }

            if (yDiff > deadZone.y)
            {
                newY = Mathf.Lerp(currentPos.y, targetPos.y, FollowSpeed * Time.deltaTime);
            }

            transform.position = new Vector3(newX, newY, zOffset);
        }
    }
}
