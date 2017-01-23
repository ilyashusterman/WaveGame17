using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    private Text cost;
	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        GetComponent<SpriteRenderer>().color = Color.black;
        cost = GetComponentInChildren<Text>();
        if (!cost) { Debug.LogWarning("Couldnt find cost text in button"); }
        else
        {
           // string starCost = defenderPrefab.GetComponent<Defender>().starCost.ToString();
          //  cost.text = starCost;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
     void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        switchWhite();
        selectedDefender = defenderPrefab;
        print(selectedDefender + " selected!");
    }


    void switchWhite()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
