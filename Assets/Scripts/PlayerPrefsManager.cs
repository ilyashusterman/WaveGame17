using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void setMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float getMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void unlockLevel(int level)
    {
        if (level <= Application.levelCount -1){
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }
    public static bool isLevelUnlocked(int level)
    {
        int appLevel = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        if (level<= Application.levelCount-1)
        {
        return appLevel == 1;
        }else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }
    public static void setDifficulty(float difficulty)
    {
        if(difficulty>=1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY, difficulty);
        }else
        {
            Debug.LogError("Difficulty out of range");
        }
    }
    public static float getDifficulty()
    {
        return  PlayerPrefs.GetFloat(DIFFICULTY);
    }
}
