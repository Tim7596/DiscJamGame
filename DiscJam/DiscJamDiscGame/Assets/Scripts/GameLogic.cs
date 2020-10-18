using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject[] blocks;
    public bool[] ready;
    bool done;
    string checking;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        for (int i = 0; i > blocks.Length; i++)
        {
            ready[i] = blocks[i].GetComponent<Block>().active;
        }

        CheckArrays(0, blocks.Length, checking);

        if (done)
        {

        }

    }


    bool CheckArrays(int lowVal, int highVal, string myArray)
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

    }
}
