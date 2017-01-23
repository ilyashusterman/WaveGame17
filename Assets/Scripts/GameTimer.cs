using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameTimer : MonoBehaviour {

    private LevelManager levelManager;
    private Slider slider;
    public float seconds = 60;
    private float timeLeft;
    private AudioSource audioSource;
    private bool levelEnded=false;
    private GameObject winLabel;

    // Use this for initialization
    void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        findYouWin();
    }

    private void findYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("you win label was not found");
        } else {
            winLabel.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update () {
        timeLeft = seconds - Time.timeSinceLevelLoad;
        // Debug.Log("Time left " + timeLeft + " seconds= " + seconds + " value" + timeLeft / seconds);
        if (timeLeft <= 0 && !levelEnded)
        {
            handleWinCondition();
        }

        slider.value = timeLeft / seconds;
    }

    private void handleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        levelEnded = true;
    }

    private void DestroyAllTaggedObjects()
    {

        GameObject [] gameobjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach(GameObject obj in gameobjects)
        {
            Destroy(obj);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}

