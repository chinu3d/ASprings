using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINextLevelButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GetComponent<AudioSource>().Play();

        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        float fadeTime = GameManager.instance.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        GameManager.instance.LoadNextLevel();
    }
}
