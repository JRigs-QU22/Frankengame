using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDrops : MonoBehaviour
{
    public GameObject objToSpawn; //object that will be spawned

    public int dropsLeft = 5; //spawns player can do

    public Vector3 below; //location beneath player
    public Text DropsReadout; //text eleemnt to display drops

    // Start is called before the first frame update
    void Start()
    {
        below = this.transform.position; //initially sets value to playrt
    }

    // Update is called once per frame
    void Update()
    {
        below = new Vector3(transform.position.x, transform.position.y-1); //updates value to position beneath player

        if (Input.GetKeyDown(KeyCode.Space) && dropsLeft != 0) //if there are drops available and space is pressed
        {
            SpawnIt(); //spawn object
            dropsLeft = dropsLeft - 1; //reduce drops by 1
            DropsReadout.text = "Spawns Left: " + dropsLeft; //update text readout
        }
    }

    void SpawnIt()
    {
        Instantiate(objToSpawn, below, Quaternion.identity); //spawns object beneath player
    }
}
