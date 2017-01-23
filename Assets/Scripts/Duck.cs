using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour {

    public AudioClip duckSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void makeSound()
    {
        AudioSource.PlayClipAtPoint(duckSound, transform.position);
    }
}
