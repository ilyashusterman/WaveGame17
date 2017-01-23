using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // boat = Gameboat.GetComponent<Boat>();
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("collided with " + other.name);
    //    Vector3 startingPosition = transform.position + new Vector3(0, 0f, 200f);
    //    GameObject beam = Instantiate(water, startingPosition, Quaternion.identity) as GameObject;
    //}
}
