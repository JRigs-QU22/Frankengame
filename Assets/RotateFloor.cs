using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloor : MonoBehaviour
{
    public bool IsUp;
    public bool IsDown;

    public bool WasLastUp;
    public bool WasLastDown;

    public float force = 10;

    public float Countdown = 7f;

    public Quaternion StartRotation;


    // Start is called before the first frame update
    void Start()
    {
        WasLastUp = false;
        WasLastDown = false;
        IsDown = true;
        IsUp = false;
        StartRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;

        if (Countdown <= 0.1)
        {
            Rotate();
            
        }
    }
/*
    private void OnEnable()
    {
       ScaleEvent.ScaleChange += Rotate;
    }
    private void OnDisable()
    {
        ScaleEvent.ScaleChange -= Rotate;
    }
*/
    void Rotate()
    {
        if (!IsUp)
        {
            GetComponent<Rigidbody2D>().angularVelocity = force;
            if (GetComponent<Rigidbody2D>().rotation >= 45)
            {
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = false;
                IsUp = true;
                Countdown = 7f;
            }
            
        }
        else if (!IsDown)
        {
            GetComponent<Rigidbody2D>().angularVelocity = -force;
            if (GetComponent<Rigidbody2D>().rotation <= 0)
            {
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = true;
                IsUp = false;
                Countdown = 7f;
            }

            //    this.GetComponent<Rigidbody2D>().rotation = 0;
        }
    }
}
