using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [HideInInspector] public SpriteRenderer sprite;

    [HideInInspector] public float timer;
    public float startTimer;

    [HideInInspector] public bool countdown;
    [HideInInspector] public bool active;
    [HideInInspector] public bool end;

    public GameLogic manager;
    

    public int digit;
    public static int[] input = new int[] { -1, -1, -1, -1 };
    private static int[] solution = new int[] { 0, 1, 2, 3 };



    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        timer = startTimer;

        sprite.color = Color.red;

        countdown = false;

        active = false;

        end = false;
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
                active = false;
                input[0] = -1;
                input[1] = -1;
                input[2] = -1;
                input[3] = -1;
            }

            
            active = true;
        }


        if (solution[0] == input[0] && solution[1] == input[1] && solution[2] == input[2] && solution[3] == input[3])
        {
            Debug.Log("Correct Answer");
            manager.done = true;
        }

    }


    public void ApplyInput()
    {
        input[0] = input[1];
        input[1] = input[2];
        input[2] = input[3];
        input[3] = digit;

        Debug.Log(input[0] + " " + input[1] + " " + input[2] + " " + input[3]);
    }

}
