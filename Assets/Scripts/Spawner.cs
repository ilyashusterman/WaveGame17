using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackerPrefabArray)
        {
            if (itsTimeToSpawn(attacker))
            {
                spawn(attacker);
            }
        }
	}

     void spawn(GameObject attacker)
    {
        GameObject attackerInstance = Instantiate(attacker) as GameObject;
        attackerInstance.transform.parent = transform;
        attackerInstance.transform.position = transform.position;
    }

    bool itsTimeToSpawn(GameObject attacker)
    {
        Attacker thisAttacker = attacker.GetComponent<Attacker>();
        float spawnDelay  = thisAttacker.seenEverySecond;
        float spawnPerSecond = 1 / spawnDelay;

        if(Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }
        float freshHold = spawnPerSecond * Time.deltaTime/5;

        return UnityEngine.Random.value < freshHold;
    
    }
}
