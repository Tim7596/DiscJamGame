using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    float dir;
    Rigidbody2D rb2d;
    public float rayLength;

    public float speed;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dir = 1;
    }

    
    void FixedUpdate()
    {

        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.up * dir, rayLength);
        RaycastHit2D right = Physics2D.Raycast(transform.position, -Vector2.up * dir, rayLength);

        Debug.DrawRay(transform.position, Vector2.up, Color.red, rayLength);
        Debug.DrawRay(transform.position, -Vector2.up, Color.blue, rayLength);


        if(left.collider != null)
        {
            Debug.Log("pog");

            if(left.collider.gameObject.name == "Top Wall")
            {
                dir = -1;
            }

            if (left.collider.gameObject.name == "Bottom Wall")
            {
                dir = 1;
            }
        }

        rb2d.velocity = new Vector2(rb2d.velocity.x, speed * dir);
    }
}
