using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter=0;

     void Start()
    {
        if (autoLoadNextLevelAfter<=0)
        {
            Debug.Log("Level auto load disabled, use positive number in seconds");
        }else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1); // by the build settings in the game load the next one
    }

}
