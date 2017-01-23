using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float damage = 50;
    private Animator animator;
    public float maxHp;
    public float currentHp;
    public float moveSpeed;
    public AudioClip deadSound;
    public GameObject body;
    public AudioClip fireSound;
    public GameObject projectile;
    public float projectileSpeed=10;
    public float attackRate = 0.2f;
	// Use this for initialization
	void Start () {
       animator= GetComponentInChildren<Animator>();
        FloatingtextController.initialize();
    }
	
	// Update is called once per frame
	void Update () {
        move();
        if (currentHp <= 0)
        {
            AudioSource.PlayClipAtPoint(deadSound, transform.position);
            Destroy(gameObject);
        }
        handleFire();
	}

    private void handleFire()
    {
        float probability = Time.deltaTime * attackRate;
        if (UnityEngine.Random.value < probability && projectile)
        {
            fire();
        }
    }
    void fire()
    {
        Vector3 startingPosition = transform.position + new Vector3(0, 0f, -2f);
        GameObject beam = Instantiate(projectile, startingPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -projectileSpeed); // rigidbody2D.velocity = new Vector3(0 , projectileSpeed, )
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        Boat player = other.gameObject.GetComponent<Boat>();
        Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile)
            {
            takeDamage(projectile.getDamage());
            projectile.hit();
            FloatingtextController.createFloatingtext(projectile.damage.ToString(), other.gameObject.transform);
            }else if (player)
        {
            Destroy(gameObject);
        }
    }
    public float getDamage()
    {
        return damage;
    }
    public void takeDamage(float amount)
    {
        currentHp = currentHp- amount;
    }
    private void move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
    }
}
