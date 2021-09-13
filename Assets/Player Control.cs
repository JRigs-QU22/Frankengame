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
        if (Input.GetKey(KeyCode.UpArrow)) //if up arrow pressed, move up
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //if down arrow pressed, move down
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //if lrft arrow pressed, move left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //if right arrow pressed, move right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
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
