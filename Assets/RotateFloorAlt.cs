using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloorAlt : MonoBehaviour
{
    public bool IsUp; //checks to see if rotated
    public bool IsDown; //checks to see if flat

    public bool IsPaused; //checks to see if rotation is paused

    public float force = 20; //force added to rotate

    public float Countdown = 7f; //how long to wait before moving

    //public Quaternion StartRotation; 
    //public Quaternion MaxRotation;

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false; //not paused by default
        IsDown = false; //is not flat by default
        IsUp = true; //is raised by default

    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime; //begin countdown automatically

        if (Countdown < 0.1) //if countdown is near zero, rotate object
        {
            Rotate(); //rotate function

        }
        if (IsPaused == true) //if object is paused, change force to zero
        {
            force = 0; 
        }
        else if (IsPaused == false) //if object isn't paused, set force back to initial 20
        {
            force = 20; 
        }
    }
    
        private void OnEnable()
        {
           PauseEvent.Paused += Paused; //on event, pause rotation
        IsPaused = true;
        }
        private void OnDisable()
        {
            PauseEvent.Paused -= Paused; //on event end resume rotation
        IsPaused = false;
        }
        
    void Rotate() //function to rotate
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
        //this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        force = 0;
        }
        
}
