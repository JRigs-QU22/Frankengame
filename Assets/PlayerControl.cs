using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float addedForce = 800;
    public Rigidbody2D rb;

    public bool Jump;

    // Start is called before the first frame update
    void Start()
    {
        Jump = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !Jump) //if up arrow pressed, move up
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x, addedForce));
            Jump = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //if lrft arrow pressed, move left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //if right arrow pressed, move right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
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
        if ((collision.gameObject.tag == "floor") && Jump == true) //if object collides with player
        {
            Jump = false;
        }
    }
}
