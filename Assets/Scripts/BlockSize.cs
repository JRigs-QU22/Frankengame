using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSize : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    float hor;
    float ver;
    public float speed = 5f;

    // number of frame for scale up or down
    public int scalingFramesUp = 0;
    public int scalingFramesDown = 0;

    public GameObject door;

    public Vector3 StartScale;

    int count = 0;


    // Use this for initialization
    void Start()
    {
        StartScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        // Set the scaling frame, the bigger number the bigger change
        if (Input.GetKeyDown(KeyCode.Q))
        {
            scalingFramesUp = 5;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale = StartScale;
        }

        // Using lerp to increasing scale. 
        // Lerp(a,b,t) when a is start value return when t = 0, b is end value return when t = 1, t is the value used to interpolate between a and b.
        // Vector3 interpolate value = a + (b - a) * t.
        if (scalingFramesUp > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 8);
            scalingFramesUp--; // reset to 0
        }
        if (scalingFramesDown > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / 4, Time.deltaTime * 8);
            scalingFramesDown--; // reset to 0
        }
        if (count == 2)
        {
            Destroy(door);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "b1")
        {
            Debug.Log("yay");
            count = count + 1;
            Debug.Log(count);
        }

        if (col.gameObject.tag == "b2")
        {
            Debug.Log("yay");
            count = count + 1;
            Debug.Log(count);
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "b1")
        {
            Debug.Log("oof");
            count = 0;
            Debug.Log(count);
        }

        if (col.gameObject.tag == "b2")
        {
            Debug.Log("oof");
            count = 0;
            Debug.Log(count);
        }
    }


    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(hor * speed, ver * speed);
    }
}

// Source: https://forum.unity.com/threads/scaling-object-using-lerp.411289/

