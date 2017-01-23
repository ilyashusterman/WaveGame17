using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource music;
    // Use this for initialization
 //   void Awake () {
 //       DontDestroyOnLoad(gameObject);
 //       Debug.Log("Dont destroy " + name);
	//}
     void Start()
    {
        //music = GetComponent<AudioSource>();
        //AudioClip currentLevel = levelMusicChangeArray[Application.loadedLevel];
        //music.volume = PlayerPrefsManager.getMasterVolume();
        //music.clip = currentLevel;
        //music.Play();
    }

     void OnLevelWasLoaded(int level)
    {
        AudioClip currentLevel = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + levelMusicChangeArray[level]);
        if (currentLevel)
        {
            music.clip = currentLevel;
            music.loop = true;
            music.Play();
        }
    }

    public void setVolume(float value)
    {
        music.volume = value;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
