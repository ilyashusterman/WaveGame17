﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

    private LevelManager levelManager;
    private void OnMouseDown()
    {
        levelManager.LoadLevel("01Start");
    }
    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
