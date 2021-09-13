using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnCountdown : MonoBehaviour
{
    float jumpForce = 300f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Countdown.TimesUp += Jump; // register for jump event
    }

    // called from Countdown (when TimesUp is called)
    void Jump(int timeNum)
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }
}
