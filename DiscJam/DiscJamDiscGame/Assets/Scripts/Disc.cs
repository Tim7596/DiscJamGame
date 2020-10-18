using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public float speed, rot_speed;
    private Vector3 old_vel;
    private Rigidbody2D rb;
    bool is_moving;
    float dieTimer = 1.5f;
    bool dieCount;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        is_moving = true;
        dieCount = false;
    }

    void FixedUpdate()
    {
        /*if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(is_moving);
            is_moving = true;
        }*/
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

        if (dieCount)
        {
            dieTimer -= Time.deltaTime;
            if(dieTimer <= 0)
            {
                Destroy(this.gameObject);
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
                collision.gameObject.GetComponent<Block>().timer = collision.gameObject.GetComponent<Block>().startTimer;
                collision.gameObject.GetComponent<Block>().countdown = true;
            }
            else
            {
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                collision.gameObject.GetComponent<Block>().countdown = false;
            }


            Debug.Log(collision.gameObject.name + " Timer: " + collision.gameObject.GetComponent<Block>().timer + " Countdown: " + collision.gameObject.GetComponent<Block>().countdown);

            dieCount = true;
        }

    }
}
