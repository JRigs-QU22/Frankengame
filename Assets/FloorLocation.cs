using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLocation : MonoBehaviour
{
    public bool IsUp;
    public bool IsDown;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        IsUp = false;
        IsDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFloor();
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
}
