using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public float interpVelocity; //float to control camera speed
    public float minDistance; //minimum camera distance
    public float followDistance; //distance to follow target
    public GameObject target; //object to track
    public Vector3 offset; //camera offset from object
    Vector3 targetPos; //position for camera to move

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position; //target position initiated at current position
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target) //if object is being tracked
        {
            Vector3 posNoZ = transform.position; //changing posNoz to new location
            posNoZ.z = target.transform.position.z; //z position matches target z position

            Vector3 targetDirection = (target.transform.position - posNoZ); //target direction for camera to move in

            interpVelocity = targetDirection.magnitude * 15f; //controls speed at which camera keeps up with player

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); //position camera is targeting to land

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f); //transform camera to land at target position

        }
    }
}

//Script taken from: https://gist.github.com/unity3diy/5aa0b098cb06b3ccbe47
