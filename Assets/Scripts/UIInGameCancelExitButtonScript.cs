using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameCancelExitButtonScript : MonoBehaviour {

    public CanvasGroup InGameMenuConfirmExitCanvasGroup;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GetComponent<AudioSource>().Play();

        GameManager.instance.resumeGame();

        InGameMenuConfirmExitCanvasGroup.alpha = 0f;
        InGameMenuConfirmExitCanvasGroup.interactable = false;
        InGameMenuConfirmExitCanvasGroup.blocksRaycasts = false;
    }
}