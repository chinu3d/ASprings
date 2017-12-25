using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameExitButtonScript : MonoBehaviour {

    public CanvasGroup InGameConfirmExitCanvasGroup;
    public CanvasGroup InGameMenuCanvasGroup;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GetComponent<AudioSource>().Play();

        InGameMenuCanvasGroup.alpha = 0f;
        InGameMenuCanvasGroup.interactable = false;
        InGameMenuCanvasGroup.blocksRaycasts = false;

        InGameConfirmExitCanvasGroup.alpha = 1f;
        InGameConfirmExitCanvasGroup.interactable = true;
        InGameConfirmExitCanvasGroup.blocksRaycasts = true;
    }
}
