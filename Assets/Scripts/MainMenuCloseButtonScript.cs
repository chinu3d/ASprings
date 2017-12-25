using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCloseButtonScript : MonoBehaviour {

    public CanvasGroup MainMenuCloseAppCanvasGroup;

    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GetComponent<AudioSource>().Play();

        MainMenuCloseAppCanvasGroup.alpha = 1f;
        MainMenuCloseAppCanvasGroup.interactable = true;
        MainMenuCloseAppCanvasGroup.blocksRaycasts = true;
    }
}