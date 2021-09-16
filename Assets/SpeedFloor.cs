using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFloor : MonoBehaviour
{

  //  public PlayerControl player;

    public bool Slow;
    // Start is called before the first frame update
    void Start()
    {
        Slow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Slow == true)
        {
            gameObject.tag = "SpeedFloor";
        }
    }

    private void OnEnable()
    {
        PauseEvent.Paused += SpeedChange;
        Slow = false;
    }
    private void Ondisable()
    {
        PauseEvent.Paused -= SpeedChange;
        Slow = true;
    }

    void SpeedChange()
    {
        gameObject.tag = "floor";
        
    }

}
