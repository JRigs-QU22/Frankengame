using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    public Rigidbody2D rb; //object rigidbody


    public int ScaleUpOrDown; //int for the random scale

    public int RandUpScale;
    public int RandDownScale;

    // number of frame for scale up or down
    public int scalingFramesUp = 0; //starting value for scaling frames up (0 means no scaling)

    public int scalingFramesDown = 0; //starting value for scaling frames down (0 means no scaling)

    public Vector3 StartScale; //stores starting scale values

    public float countdownTime = 1f;

    // Use this for initialization
    void Start()
    {
        StartScale = transform.localScale; //reads and stores initial scal values before a change
    }

    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;

        if (countdownTime <= 0)
        {
            ScaleUpOrDown = Random.Range(1, 10);
            countdownTime = 1f;
        }
      //ScaleUpOrDown = Random.Range(1,10); //sets scaling frames to a random range
                                            // hor = Input.GetAxisRaw("Horizontal");
                                            //  ver = Input.GetAxisRaw("Vertical");

        // Set the scaling frame, the bigger number the bigger change
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     scalingFramesUp = ScaleRand;
        // }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     scalingFramesDown = ScaleRand;
        //  }

        // Using lerp to increasing scale. 
        // Lerp(a,b,t) when a is start value return when t = 0, b is end value return when t = 1, t is the value used to interpolate between a and b.
        // Vector3 interpolate value = a + (b - a) * t.
        if (scalingFramesUp > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 8); //transforms scale up
            scalingFramesUp--; // reset to 0
        }
        if (scalingFramesDown > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / 4, Time.deltaTime * 8); //transforms scale down
            scalingFramesDown--; // reset to 0
        }

    }
    private void OnEnable()
    {
       
        ScaleEvent.ScaleChange += ScaleUp; //enables event
    }

    private void OnDisable()
    {
        ScaleEvent.ScaleChange -= ScaleUp; //disables event
        
    }


    void ScaleUp (int num)
    {
        if (num == 0)
        {
            

            if (ScaleUpOrDown > 5)
            {
                RandUpScale = Random.Range(3, 5);
                scalingFramesUp = RandUpScale; //sets the scale based on scaling frames
            }
            else if (ScaleUpOrDown <= 5)
            {
                RandDownScale = Random.Range(3, 5);
                scalingFramesDown = RandDownScale; //sets the scale based on scaling frames
            }
            ScaleUpOrDown = ScaleUpOrDown; //sets the scale based on scaling frames
        }
        else if (num == 1)
        {
            transform.localScale = StartScale; //restores scale to initial value
        }
        
    }

    void ScaleDown ()
    {
        transform.localScale = StartScale; //restores scale to initial value
    }
}
