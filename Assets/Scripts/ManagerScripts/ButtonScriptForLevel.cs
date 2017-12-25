using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptForLevel : MonoBehaviour {

    public int moduleNumber;
    public int levelNumber;

    // Use this for initialization
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GetComponent<AudioSource>().Play();

        StartCoroutine(changeScene());
        //changeScene();
    }

    IEnumerator changeScene()
    {
        float fadeTime = GameManager.instance.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        GameManager.instance.LoadSceneWithName("Scene" + moduleNumber + "_" + levelNumber);
    }
}