using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLocation : MonoBehaviour
{
    public bool IsUp; //checks to see if high already
    public bool IsDown; //checks to see if low
    public float Speed; //speed to control movement

    public bool IsStopped;

    // Start is called before the first frame update
    void Start()
    {
        IsUp = false; //not high by default
        IsDown = true; //low by default
        IsStopped = false; //is moving by default
    }

    // Update is called once per frame
    void Update()
    {
        MoveFloor(); //move floor up and down

        if (IsStopped == false) // if floor isn't stopped, speed is starting 4 value
        {
            Speed = 4;
        }
        else if (IsStopped == true) // if floor is stopped, speed changes to zero
        {
            Speed = 0;
        }
    }

    private void OnEnable() //on event stop movement
    {
        PauseEvent.Paused += Stopped;
        IsStopped = true;
    }
    private void OnDisable() //on event end resume movement
    {
        PauseEvent.Paused -= Stopped;
        IsStopped = false;
    }

    void MoveFloor()
    {
        if (!IsUp) //if floor is down, move up until it hits the y position of 5, then flip bools to move down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
            if (transform.position.y > 5f)
            {
                IsUp = true;
                IsDown = false;
            }

        }
        else if (!IsDown) // if floor is up, move down until it hits y position of -10, then flip bools to move up
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
            if (transform.position.y < -10f)
            {
                IsUp = false;
                IsDown = true;
            }

        }
    }

    private void Stopped() //void for event to change movement speed
    {
        Speed = 0;
    }
   
    
}
