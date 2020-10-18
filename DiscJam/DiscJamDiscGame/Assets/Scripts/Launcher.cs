using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject disc;
    public int limit;
    int num;
    bool shoot;


    void Start()
    {
        num = 0;
        shoot = true;
    }


    void Update()
    {

        if (Input.GetButtonDown("Jump") && shoot || Input.GetKeyDown(KeyCode.Space) && shoot)
        {
            Instantiate(disc, transform.position, transform.rotation);
            num++;
            Debug.Log("shoot");
        }

        if(limit <= num)
        {
            shoot = false;
        }

        if (Input.GetKey(KeyCode.W)){

            transform.Rotate(0, 0, .5f);

        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.Rotate(0, 0, -.5f);

        }

    }
}
