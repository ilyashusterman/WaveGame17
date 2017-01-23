using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySecond;
    private MoveEnemy moveEnemy;
    private Animator animator;
    private float currentSpeed;
    private GameObject currentTarget;
    private GameObject parent;
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    // Use this for initialization
    void Start () {
        //Rigidbody2D newRigidbody = gameObject.AddComponent<Rigidbody2D>();
        // newRigidbody.isKinematic = true;
        animator = GetComponent<Animator>();
        moveEnemy = GameObject.FindObjectOfType<MoveEnemy>();
        lastWaypointSwitchTime = Time.time;
       // waypoints = moveEnemy.getPoints();
    }
    // Update is called once per frame
    void Update () {
         transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        //TODO move in direction in the space;
       // spawnAttackerDirection();
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}
    void spawnAttackerDirection()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        // 2 
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / currentSpeed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;

        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        // 3 
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                // 3.a 
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;

                changeDirection();
                // TODO: Rotate into move direction
                endPosition = waypoints[currentWaypoint + 1].transform.position;
                //transform.rotation = Quaternion.LookRotation(endPosition-startPosition);
                //transform.LookAt(endPosition);
            }
        }
    }

    private void changeDirection()
    {
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (-newEndPosition + newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        gameObject.transform.rotation =
            Quaternion.AngleAxis(rotationAngle, Vector3.forward);

    }


    public void setSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void strikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.dealDamage(damage);
            }
        }
        Debug.Log(name+" caused damage :" + damage);
    }

    public void attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
