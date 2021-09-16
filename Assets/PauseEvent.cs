using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEvent : MonoBehaviour
{
    public delegate void PauseEffect();
    public static event PauseEffect Paused;

    public float countdownEverySeconds = 1f; //reduces time by 1f each seconf
    public float counter = 5f; //keeps track of current remaining time

    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F)) //if player presses space, toggle the visibility of the attached object on or off
        {
            isRunning = true;
           

        }

        if (isRunning == true)
        {
            Paused();
            counter -= Time.deltaTime; //reduce counter


        }
        //Paused();
        //counter -= Time.deltaTime; //reduce counter
        //isRunning = true;

        // update counter 
        if (counter < 0)
        {
            isRunning = false;
            counter = countdownEverySeconds;


        }

        // update width
        float percentDone = counter / countdownEverySeconds; //reduces bar based on counting down time
        transform.localScale = new Vector2(percentDone, 1f); //scales bar based on percentage complete

    }

}
