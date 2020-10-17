using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public float speed, rot_speed;
    private Vector3 old_vel;
    private Rigidbody2D rb;
    bool is_moving;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        is_moving = false;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            is_moving = true;
        }
        if (is_moving)
        {
            rb.velocity = transform.right * speed;
            old_vel = rb.velocity;
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Rotate(0, 0, -rot_speed);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Rotate(0, 0, rot_speed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];

        Vector3 new_vel = Vector3.Reflect(old_vel, contact.normal);

        rb.velocity = new_vel;
        Quaternion rotation = Quaternion.FromToRotation(old_vel, new_vel);
        transform.rotation = rotation * transform.rotation;

        if (collision.gameObject.tag == "LetterBlock")
        {
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

    }
}
