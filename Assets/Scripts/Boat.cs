using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {
    public enum Status
    {
        Right, Left, Fire
    }
    // Use this for initialization
    public float speed = 15;
    private float minX, maxX;
    public float padding = 0.49f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    public float maxHealth = 250;
    public float health = 250;
    public AudioClip fireSound;
    public GameObject healthBar;

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftMost.x + padding;
        maxX = rightMost.x - padding;
    }
	
	// Update is called once per frame
	void Update () {
        handleInput();
    }

    public void handleInput(Status status)
    {
        switch (status)
        {
   //         case Status.Fire: InvokeRepeating("fire", 0.000001f, firingRate);  break;
            case Status.Right: transform.Translate(Vector3.right * Time.deltaTime * speed); break;
            case Status.Left: transform.Translate(Vector3.left * Time.deltaTime * speed); break;
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    CancelInvoke("fire");
        //}
        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //InvokeRepeating("fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
           // CancelInvoke("fire");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
       // float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    public void makeMove()
    {
        Debug.Log("moving");
    }

}
