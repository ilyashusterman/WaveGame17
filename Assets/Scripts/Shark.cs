using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    public float damage = 50;
    public float maxHp;
    public float currentHp;
    public float moveSpeed;
    public GameObject body;
    // Use this for initialization
    void Start()
    {
        FloatingtextController.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Boat player = other.gameObject.GetComponent<Boat>();
        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            //body.transform
            FloatingtextController.createFloatingtext(projectile.damage.ToString(), other.gameObject.transform);
        }
        else if (player)
        {
            player.takeDamage(damage);
        }
    }
    public void takeDamage(float amount)
    {
        currentHp = currentHp - amount;
    }
    private void move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
