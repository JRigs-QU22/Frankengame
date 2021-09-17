using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEvent : MonoBehaviour
{
    //public delegate void Scale(); //delegate for event
    //public static event Scale ScaleChange; //static event to call for a scale change

    public static event Action ScaleChange = delegate {};
   // public float countdown = 7f;
    //public float CountReduce = 1f;
    public float countdownEverySeconds = 1f; //reduces time by 1f each seconf
    public float counter; //keeps track of current remaining time

    void Start()
    {
        // init the counter
        counter = countdownEverySeconds; //sets counter to initial seconds
    }

    void Update()
    {
        // if countdown is up
        if (counter < 0)
        {
            ScaleChange(); // call the delegate
            counter = countdownEverySeconds; //sets counter to current seconds left
        }
        if (counter >= 7)
        {
            ScaleChange();
            counter = countdownEverySeconds;
        }

        // update width
        float percentDone = counter / countdownEverySeconds; //reduces bar based on counting down time
        transform.localScale = new Vector2(percentDone, 1f); //scales bar based on percentage complete

        // update counter 
        counter -= Time.deltaTime; //reduce counter
    }
}
