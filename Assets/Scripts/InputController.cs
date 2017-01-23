using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private Boat boat;
    private Rigidbody rbody;
    public float accellerateSpeed = 1000f;
    public float turnSpeed = 1000f;
    private Animator animator;
    // Use this for initialization
    void Start () {
        boat = GetComponent<Boat>();
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        handleInput();
	}

    private void handleInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);
    }

    public void makeMoveRight()
    {
        Debug.Log("movingRight");
        boat.transform.Translate(Vector3.right * Time.deltaTime * boat.speed);
        animator.SetBool("moveLeft", false);
        animator.SetBool("moveRight", true);
    }
    public void makeMoveLeft()
    {
        Debug.Log("movingLeft");
        boat.transform.Translate(Vector3.left * Time.deltaTime * boat.speed);
        animator.SetBool("moveRight", false);
        animator.SetBool("moveLeft", true);
    }
    public void fire()
    {
        boat.fire();
    }
}
