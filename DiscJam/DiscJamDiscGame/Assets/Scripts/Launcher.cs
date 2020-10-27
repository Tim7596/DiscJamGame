using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject disc;
    public int limit;
    int num;
    bool shoot;

    Vector3 pos;
    Vector3 dir;
    float angle;


    void Start()
    {
        num = 0;
        shoot = true;
    }


    void Update()
    {

        if (Input.GetButtonDown("Jump") && shoot || Input.GetKeyDown(KeyCode.Space) && shoot || Input.GetButtonDown("Fire1") && shoot || Input.GetKeyDown(KeyCode.Mouse1) && shoot)
        {
            Instantiate(disc, transform.position, transform.localRotation);
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

        pos = Camera.main.WorldToScreenPoint(transform.position);
        dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
