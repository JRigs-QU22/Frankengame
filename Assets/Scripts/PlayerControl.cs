using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float LeftSpeed; //left movement speed
    public float RightSpeed; //right movement speed
    public float addedForce = 800; //force to add to jump
    public Rigidbody2D rb; //player rigidbody

    public GameObject Platform;

    public bool Jump; //checks to see if player is jumping

    public bool SlowSpeed; //bool to see if movement is slow or fast

    // Start is called before the first frame update
    void Start()
    {
        Jump = false; //player is not jumping by default
        SlowSpeed = true; //slow speed enabled by default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Jump) //if W key pressed, jump
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x, addedForce));
            Jump = true; //says player is jumping
            LeftSpeed = -6f; //slows left speed while in air
            RightSpeed = 6f; //slows right speed while in air

        }
        else if (Input.GetKey(KeyCode.A)) //if A key pressed, move left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(LeftSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D)) //if D key pressed, move right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(RightSpeed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //if no key pressed, stop
        }

        if (Input.GetKey(KeyCode.R)) // if player presses r 
        {
            SceneManager.LoadScene("MainGamev2"); //reload the level
        }

        if (SlowSpeed == true)
        {
            LeftSpeed = -12f; //restore left speed to default
            RightSpeed = 12f;//restore Right speed to default
        }
        else
        {
            
        }
    }

    private void OnEnable() //runs event and increases player speed
    {
        PauseEvent.Paused += PlayerSpeed; 
        SlowSpeed = false;
    }
    private void OnDisable() //stops event and reduces speed to normal
    {
        PauseEvent.Paused -= PlayerSpeed;
        SlowSpeed = true;
    }

    void PlayerSpeed()
    {
        //SlowSpeed = !SlowSpeed;
        LeftSpeed = -20f; //increases left speed
        RightSpeed = 20f; //increases right speed
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "LAVA")) //if player hits the floor
        {
            SceneManager.LoadScene("MainGamev2"); //reload level
        }

        if ((collision.gameObject.tag == "floor") && Jump == true) //if player is on a floor and is jumping
        {
            Jump = false; //sets jumping to false to allow jumping
            LeftSpeed = -20f; //restore left speed to default
            RightSpeed = 20f; //restore right speed to default
            Debug.Log("hit");
        }

    }
}



