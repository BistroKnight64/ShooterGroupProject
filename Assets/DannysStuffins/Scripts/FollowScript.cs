using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    //this script is self explainitory i think
    public GameObject thingToFollow;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = thingToFollow.transform.position + offset;
    }
}
