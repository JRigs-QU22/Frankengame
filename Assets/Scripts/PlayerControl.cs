using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float LeftSpeed = -20f; //left movement speed
    public float RightSpeed = 20f; //right movement speed
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
            LeftSpeed = -10f; //slows left speed while in air
            RightSpeed = 10f; //slows right speed while in air

        }
        else if (Input.GetKey(KeyCode.A)) //if left arrow pressed, move left
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
            SceneManager.LoadScene("MainGamev2"); //reload the level
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "floor" || collision.gameObject.tag == "floorSpawn") && Jump == true) //if player is on a floor and is jumping
        {
            Jump = false; //sets jump to false to allow jumping again
            LeftSpeed = -20f; //restore left speed to default
            RightSpeed = 20f; //restore right speed to default
        }
        if((collision.gameObject.tag == "LAVA")) //if player is hit by obstacle
        {
            SceneManager.LoadScene("MainGamev2"); //reload levels
        }
        if ((collision.gameObject.tag == "SpeedFloor") && Jump == true) //if player is on a floor and is jumping
        {
            Jump = false;
            LeftSpeed = -5f; //restore left speed to default
            RightSpeed = 5f; //restore right speed to default
        }
    }
}
