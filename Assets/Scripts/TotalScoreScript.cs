using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.GetComponent<Text>().text = "Total Score: " + PlayerPrefs.GetInt("TotalScore", 0);
    }
}
