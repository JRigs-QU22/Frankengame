using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6.7f) //if object moves too far off screen
        {
            Destroy(gameObject); //move object back to marked starting position
        }
    }
}
