using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.GetComponent<Text>().text = "Level Score: " + PlayerPrefs.GetInt(GameManager.instance.currentLevelSceneName + "_score", 0);

    }
}
