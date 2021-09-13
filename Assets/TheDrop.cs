using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDrop : MonoBehaviour
{
    public GameObject objToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SpawnIt();
        }
    }
    void SpawnIt()
    {
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
    }
}
