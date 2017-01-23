using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(PlayerPrefsManager.getMasterVolume());
        PlayerPrefsManager.setMasterVolume(0.3f);
        print(PlayerPrefsManager.getMasterVolume());

        print("is level unlock for 2 ?" + PlayerPrefsManager.isLevelUnlocked(2));
        PlayerPrefsManager.unlockLevel(2);
        print("is level unlock for 2 ?" + PlayerPrefsManager.isLevelUnlocked(2));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
