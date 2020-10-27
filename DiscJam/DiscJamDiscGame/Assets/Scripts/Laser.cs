using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    bool down;
    float startTimer;
    float startDown;
    public float timer;
    public float downTimer;
    public GameObject beam;

    
    void Start()
    {
        startTimer = timer;
        startDown = downTimer;
        down = true;
        downTimer = 2;
    }

    
    void Update()
    {

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            down = false;
        } else
        {
            down = true;
        }


        if (down == false)
        {
            beam.SetActive(true);
            downTimer -= Time.deltaTime;
            if(downTimer <= 0)
            {
                down = true;
                timer = startTimer;
            }

        } else
        {
            beam.SetActive(false);
            downTimer = startDown;
        }


    }
}
