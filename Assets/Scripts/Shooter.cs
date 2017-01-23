using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private Animator animator;
    private GameObject projectileParent;
    private Spawner spawnerLane;
    // Use this for initialization
    void Start () {

        animator = GameObject.FindObjectOfType<Animator>();
        //Creates the parent if neceseray
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        setMyLaneSpawner();
        print(spawnerLane);

    }
	
    void setMyLaneSpawner()
    {
        Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach(Spawner thisSpawner in spawners)
        {
            if (thisSpawner.transform.position.y == transform.position.y)
            {
                spawnerLane = thisSpawner;
                return;
            }
        }
        Debug.LogError(name + " cant find spawner in lane");
    }
	// Update is called once per frame
	void Update () {
        if (isAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }else
        {
            animator.SetBool("isAttacking", false);
        }
	}

    private bool isAttackerAheadInLane()
    {
        if (spawnerLane.transform.childCount <= 0)
        {
            return false;
        }
        foreach(Transform attacker in spawnerLane.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    private void fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }



}
