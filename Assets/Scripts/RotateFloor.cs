using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloor : MonoBehaviour
{
    public bool IsUp; //checks to see if object is rotated
    public bool IsDown; //checks to see if object is flat

    public bool IsPaused; //checks to see if object is paused

    public float force = 20; //force added to rotate

    public float Countdown = 5f; //countdown in between movements

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false; //object not paused by default
        IsDown = true; //Object flat by default
        IsUp = false; //object rotated by default
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime; //begin countdown on game start

        if (Countdown < 0.1) //when countdown reaches near zero
        {
            Rotate(); //rotate object
            
        }
        if (IsPaused == true) // If object is paused, add no force
        {
            force = 0;
        }
        else if (IsPaused == false) //If object is not paused, add initial force
        {
            force = 20;
        }
    }

    private void OnEnable() //on event pause object
    {
       PauseEvent.Paused += Paused; 
        IsPaused = true;
    }
    private void OnDisable() //on event end, unpause object
    {
        PauseEvent.Paused -= Paused;
        IsPaused = false;
    }
    
    void Rotate()
    {
        if (!IsUp) //if object is flat, add force until 45 degrees is reached, then stop rotation, reset countdown, and swap bool value
        {
            this.GetComponent<Rigidbody2D>().angularVelocity = force;
            if (this.GetComponent<Rigidbody2D>().rotation > 45)
            {
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = false;
                IsUp = true;
                Countdown = 7f;
            }
            
        }
        else if (!IsDown) //if object is rotated, add negative force until 0 degrees is reached, then stop rotation, reset countdown, and swap bool values
        {
            this.GetComponent<Rigidbody2D>().angularVelocity = -force;
            if (this.GetComponent<Rigidbody2D>().rotation < 0)
            {
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = true;
                IsUp = false;
                Countdown = 7f;
            }

            //    this.GetComponent<Rigidbody2D>().rotation = 0;
        }
    }

    void Paused() //function changes force to zero
    {
        force = 0;
        //this.GetComponent<Rigidbody2D>().angularVelocity = 0;

    }
}
