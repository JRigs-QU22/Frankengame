using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //if up arrow pressed, move up
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(5000, 10000));
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //if down arrow pressed, move down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20);
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
            SceneManager.LoadScene("VisibilityToggle"); //reload the level
        }
    }
}
