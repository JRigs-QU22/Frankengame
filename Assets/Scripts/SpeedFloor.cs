using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFloor : MonoBehaviour
{

    public bool Slow; //sees if movement is slowed

    // Start is called before the first frame update
    void Start()
    {
        Slow = true; //slow by default
    }

    // Update is called once per frame
    void Update()
    {
        if (Slow == true) //if movement is slowed
        {
            gameObject.tag = "SpeedFloor"; //use slowing tag
        }
        else if (Slow == false) //if movement isn't slowed
        {
            gameObject.tag = "floor"; //use normal tag
        }
    }

    private void OnEnable()
    {
        PauseEvent.Paused += SpeedChange; //on event, remove slowing
        Slow = false; //disable slowing
    }
    private void OnDisable()
    {
        PauseEvent.Paused -= SpeedChange; //on event end, enable slowig
        Slow = true; //enable slowing
    }

    void SpeedChange()
    {
        Slow = false;
        //gameObject.tag = "floor"; //function to change tag to remove slowing
        
    }

}
