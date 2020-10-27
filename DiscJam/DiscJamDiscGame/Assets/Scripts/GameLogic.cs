using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    public string NextLevel;
    [HideInInspector] public bool done;
    string checking;

    public static int[] solution = new int[] { 3, 2, 1, 0 };

    void Start()
    {
        done = false;
    }

    
    void Update()
    {

        /*for (int i = 0; i > blocks.Length; i++)
        {
            ready[i] = blocks[i].GetComponent<Block>().active;
        }

        CheckArrays(0, blocks.Length, checking);*/

        if (done)
        {
            SceneManager.LoadScene(NextLevel);
        }


        

    }


    /*bool CheckArrays(int lowVal, int highVal, string myArray)
    {

        for(int i = lowVal; i < highVal; i++)
        {


            switch (myArray)
            {

                case "ready":
                    if (ready[i] == false)
                    {
                        done = false;
                    }
                    break;

                case "notReady":
                    if (ready[i] == true)
                    {
                        done = true;
                    }
                    break;
            }
        }

        if (done)
        {
            return true;
        } else
        {
            return false;
        }

    }*/


    
    }

