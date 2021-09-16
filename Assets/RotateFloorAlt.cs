using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloorAlt : MonoBehaviour
{
    public bool IsUp;
    public bool IsDown;

    public bool WasLastUp;
    public bool WasLastDown;

    public float force = 10;

    public float Countdown = 7f;

    public Quaternion StartRotation;
    public Quaternion MaxRotation;

    // Start is called before the first frame update
    void Start()
    {
        WasLastUp = false;
        WasLastDown = false;
        IsDown = false;
        IsUp = true;

    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;

        if (Countdown < 0.1)
        {
            Rotate();

        }
    }
    /*
        private void OnEnable()
        {
           PauseEvent.Paused += Paused;
        }
        private void OnDisable()
        {
            PauseEvent.Paused -= Paused;
        }
        */
    void Rotate()
    {
        if (!IsUp)
        {
            this.GetComponent<Rigidbody2D>().angularVelocity = force;
            if (this.GetComponent<Rigidbody2D>().rotation > 45)
            {
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = false;
                IsUp = true;
                Countdown = 7f;
            }

        }
        else if (!IsDown)
        {
            this.GetComponent<Rigidbody2D>().angularVelocity = -force;
            if (this.GetComponent<Rigidbody2D>().rotation < 0)
            {
                this.GetComponent<Rigidbody2D>().angularVelocity = 0;
                IsDown = true;
                IsUp = false;
                Countdown = 7f;
            }

            //    this.GetComponent<Rigidbody2D>().rotation = 0;
        }
    }
    /*
        void Paused()
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        */
}
