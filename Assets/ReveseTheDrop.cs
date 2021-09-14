using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReveseTheDrop : MonoBehaviour
{
    public GameObject objToSpawn;

    public float dropTIme = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dropTIme -= Time.deltaTime;

        if (dropTIme <= 0.1)
        {
            SpawnIt();
            dropTIme = 5f;
        }
    }
    void SpawnIt()
    {
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
    }
}