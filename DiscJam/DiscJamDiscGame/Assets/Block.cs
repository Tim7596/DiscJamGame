using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [HideInInspector] public SpriteRenderer sprite;

    [HideInInspector] public float timer;
    public float startTimer;

    [HideInInspector] public bool countdown;



    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        timer = startTimer;

        sprite.color = Color.red;

        countdown = false;
    }

    
    void Update()
    {

        if (countdown)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                sprite.color = Color.red;
                countdown = false;
            }

            Debug.Log(this.gameObject.name + " Timer: " + timer + " Countdown: " + countdown);
        }

    }
}
