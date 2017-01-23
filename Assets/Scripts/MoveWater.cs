using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour {

    public GameObject boat;
    private Boat gameBoat;
	// Use this for initialization
	void Start () {
        gameBoat = boat.GetComponent<Boat>();
	}

    private void move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * gameBoat.waterSpeed);
    }

    // Update is called once per frame
    void Update () {
        move();
		
	}
}
