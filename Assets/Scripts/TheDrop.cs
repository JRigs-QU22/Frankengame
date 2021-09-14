using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDrop : MonoBehaviour
{
    public GameObject objToSpawn; //object that will be spawned

    public float dropTIme = 5f; //timer between spawns


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dropTIme -= Time.deltaTime; //deducts time falling

        if (dropTIme <= 0.1) //If drop time hits near zero
        {
            SpawnIt(); //instantiate object
            dropTIme = 5f; //reset timer
        }
    }
    void SpawnIt()
    {
        Instantiate(objToSpawn, transform.position, Quaternion.identity); //spawns object beneath player
    }
}
