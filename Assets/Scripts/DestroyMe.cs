using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMe : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -26.7f || transform.position.y > 26.7f) //if object moves too far off screen
        {
            Destroy(gameObject); //destorys object
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "floorSpawn")) //if object collides with player
        {
            Destroy(gameObject); //destroy object
        }
    }
}
