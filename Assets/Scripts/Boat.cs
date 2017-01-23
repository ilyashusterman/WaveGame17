using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

    // Use this for initialization
    public float speed ;
    public float waterSpeed;
    private float minX, maxX;
    public float padding = 0.49f;
    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    public float maxHealth = 250;
    public float health = 250;
    public AudioClip fireSound;
    public GameObject healthBar;
    public Vector3 directionRotation;
    private float moveSpeed = 10f;
    private float turnSpeed = 50f;
    public float angle = 45;
    private Animator animator;
    public float spaceDistance=35f;
    public int cash;

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z+spaceDistance;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        animator = GetComponent<Animator>();
        minX = leftMost.x + padding;
        maxX = rightMost.x - padding;
        cash = 0;
        // Debug.Log("animator=" + animator);
    }
    public void fire()
    {
        Vector3 startingPosition = transform.position + new Vector3(0, 0.5f, 1.5f);
        GameObject beam = Instantiate(projectile, startingPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, projectileSpeed); // rigidbody2D.velocity = new Vector3(0 , projectileSpeed, )
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    // Update is called once per frame
    void Update () {
        handleInput();
    }

    private void handleDeath()
    {
            Debug.Log("you died!");
            gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided with " + collision.name);
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (missile)
        {
            //     Debug.Log("Player hit!");
            health -= missile.getDamage();
            missile.hit();
            if (health <= 0)
            {
                handleDeath();
                setHealthBar(0f);
            }
            else
            {
            setHealthBar();
            }
            //    Debug.Log("hit!");
        }
        if (enemy)
        {
            health -= enemy.getDamage();
            if (health <= 0)
            {
                handleDeath();
                setHealthBar(0f);
            }
            else
            {
                setHealthBar();
            }
        }

    }

    private void setHealthBar(float v)
    {
        healthBar.transform.localScale = new Vector3(v, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("fire");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", true);
        }
        else if (!Input.imeIsSelected)
        {
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", false);
        }
        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void takeDamage(float amount)
    {
        health = health - amount;
        setHealthBar();
    }

    void setHealthBar()
    {
        float currentHealth = this.health / this.maxHealth;
           Debug.Log("health = " + health + "maxHealth = " + maxHealth + " currentHealth = " + currentHealth);
        healthBar.transform.localScale = new Vector3(currentHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
