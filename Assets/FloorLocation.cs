using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLocation : MonoBehaviour
{
    public bool IsUp;
    public bool IsDown;
    public float Speed;

    public bool IsStopped;

    // Start is called before the first frame update
    void Start()
    {
        IsUp = false;
        IsDown = true;
        IsStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFloor();

        if (IsStopped == false)
        {
            Speed = 4;
        }
        else if (IsStopped == true)
        {
            Speed = 0;
        }
    }

    private void OnEnable()
    {
        PauseEvent.Paused += Stopped;
        IsStopped = true;
    }
    private void OnDisable()
    {
        PauseEvent.Paused -= Stopped;
        IsStopped = false;
    }

    void MoveFloor()
    {
        if (!IsUp)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
            if (transform.position.y > 5f)
            {
                IsUp = true;
                IsDown = false;
            }

        }
        else if (!IsDown)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
            if (transform.position.y < -10f)
            {
                IsUp = false;
                IsDown = true;
            }

        }
    }

    private void Stopped()
    {
        Speed = 0;
    }
   
    
}
