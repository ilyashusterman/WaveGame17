using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    public float volume = 0.8f, difficulty = 2f;
    public Slider volumeSlider, difficultySlider;
    public LevelManager levelManager;
    private MusicManager musicManager;
    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log("MusicManager is " + musicManager);
        volumeSlider.value = PlayerPrefsManager.getMasterVolume();
        difficultySlider.value = PlayerPrefsManager.getDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
        musicManager.setVolume(volumeSlider.value);
	}

    public void saveAndExit()
    {
        PlayerPrefsManager.setMasterVolume(volumeSlider.value);
        PlayerPrefsManager.setDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01Start");
    }
    public void setDefaults()
    {
        volumeSlider.value = volume;
        difficultySlider.value = difficulty;
    }
}
