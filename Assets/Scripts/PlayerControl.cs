﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float LeftSpeed = -20f;
    public float RightSpeed = 20f;
    public float addedForce = 800; //force to add to jump
    public Rigidbody2D rb; //player rigidbody

    public GameObject Platform;

    public bool Jump; //checks to see if player is jumping

    // Start is called before the first frame update
    void Start()
    {
        Jump = false; //player is not jumping by default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Jump) //if up arrow pressed, jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x, addedForce));
            Jump = true; //says player is jumping
            LeftSpeed = -10f;
            RightSpeed = 10f;

        }
        else if (Input.GetKey(KeyCode.A)) //if lrft arrow pressed, move left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(LeftSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D)) //if right arrow pressed, move right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(RightSpeed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //if no arrow pressed, stop
        }

        if (Input.GetKey(KeyCode.R)) // if player presses r 
        {
            SceneManager.LoadScene("MainGame"); //reload the level
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "floor" || collision.gameObject.tag == "floorSpawn" ) && Jump == true) //if player is on floor and is jumping
        {
            Jump = false; //sets jump to false to allow jumping again
            LeftSpeed = -20f;
            RightSpeed = 20f;
        }

    }
}
