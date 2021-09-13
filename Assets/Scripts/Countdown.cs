using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    // event - you have to initialize this to nothing or you'll get a null error
    // if nothing is subscribed to it
    public static event Action<int> TimesUp = delegate {};
    public float countdownEverySeconds = 1f;
    public float counter;

    void Start()
    {
        // init the counter
        counter = countdownEverySeconds;
    }

    void Update()
    {
        // if countdown is up
        if (counter < 0)
	    {
            TimesUp(0); // call the delegate
            counter = countdownEverySeconds;
        }

        // update width
        float percentDone = counter/countdownEverySeconds;
        transform.localScale = new Vector2(percentDone, 1f);

        // update counter 
        counter -= Time.deltaTime;
    }
}
