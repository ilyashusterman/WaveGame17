using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;
    public float maxHealth=500;
    public GameObject healthBar;

    private void Start()
    {
        FloatingtextController.initialize();
    }
    public void dealDamage(float damage)
    {
      health -= damage;
            setHealthBar();
        handleTextDamage(damage);
        if (health <= 0)
        {
            //optionally trigger animation
            DestroyObject();
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    void setHealthBar()
    {
        float currentHealth = this.health / this.maxHealth;
      //    Debug.Log("health = " + health + "maxHealth = " + maxHealth + " currentHealth = " + currentHealth);
        healthBar.transform.localScale = new Vector3(currentHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void handleTextDamage(float damage)
    {
        int damageText = ((int)damage);
        Transform textTransform = healthBar.transform;
        FloatingtextController.createFloatingtext(damageText.ToString(), healthBar.transform);
    }
    void handleTextCriticleDamage(float damage)
    {
        int damageText = ((int)damage);
        FloatingtextController.createCriticalText(damageText.ToString(), healthBar.transform);
    }
}
