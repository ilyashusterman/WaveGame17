using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    //Ball prefab with Ball Component
    public Boat boat;

    private Vector3 offset;
    // Use this for initialization
    void Start()
    { // calculate offset by the top camera and ball
        offset = transform.position - boat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      //  if (transform.position.z <= 1829) // In front of head pin position on floor 
            transform.position = boat.transform.position + offset; // give the camera its position each frame with offset on the ball
    }
}
