using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDrops : MonoBehaviour
{
    public GameObject objToSpawn;

    public int dropsLeft = 5;

    public Vector3 below;
    public Text DropsReadout;

    // Start is called before the first frame update
    void Start()
    {
        below = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        below = new Vector3(transform.position.x, transform.position.y-1);

        if (Input.GetKeyDown(KeyCode.Space) && dropsLeft != 0)
        {
            SpawnIt();
            dropsLeft = dropsLeft - 1;
            DropsReadout.text = "Spawns Left: " + dropsLeft;
        }
    }

    void SpawnIt()
    {
        Instantiate(objToSpawn, below, Quaternion.identity);
    }
}
