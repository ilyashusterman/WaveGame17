using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseShredder : MonoBehaviour {

    public int healthPoints = 3;
    public string loseScreen;
    // Use this for initialization
    private LevelManager levelManager;
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Debug.Log(levelManager);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>())
        {
            Destroy(collision.gameObject);
            Debug.Log("health point is " + healthPoints);
            if (healthPoints <= 0)
            {
                loseGame();
            }
            healthPoints -= 1;
            Debug.Log("health point is " + healthPoints);
        }
    }

     void loseGame()
    {
        levelManager.LoadLevel(loseScreen);
    }
}
