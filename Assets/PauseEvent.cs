using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseEvent : MonoBehaviour
{
    public delegate void PauseEffect(); //event delegate 
    public static event PauseEffect Paused; //public event

    public float countdownEverySeconds = 1f; //reduces time by 1f each second
    public float counter = 3f; //keeps track of current remaining time

    public bool isRunning; //checks to see if event is running

    public int PauseUses; //Pause limit

    public Text UsesLeft; //Text Element to indicate Pauses

    
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false; //event is false by default
        PauseUses = 3; //you can pause platforms 3 times
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PauseUses > 0) //if player presses f, change bool to run event
        {
            isRunning = true;
            

        }

        if (isRunning == true) //if event is true, run paused event
        {
            Paused(); //runs event
            
            counter -= Time.deltaTime; //reduce counter


        }

       
        if (counter < 0) //if counter reaches zero, change bool, end event, and reset counter
        {
            isRunning = false; // disables event run bool and stops event
            counter = countdownEverySeconds; //counter equals time remaining
            PauseUses = PauseUses - 1; //removes 1 use

        }
        
        UsesLeft.text = "Stops Left: " + PauseUses; //readout of uses left

        // update width
        float percentDone = counter / countdownEverySeconds; //reduces bar based on counting down time
        transform.localScale = new Vector2(percentDone, 1f); //scales bar based on percentage complete

    }

}
