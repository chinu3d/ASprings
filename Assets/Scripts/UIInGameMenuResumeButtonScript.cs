using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameMenuResumeButtonScript : MonoBehaviour
{
    public CanvasGroup InGameMenuCanvasGroup;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        GameManager.instance.resumeGame();

        InGameMenuCanvasGroup.alpha = 0f;
        InGameMenuCanvasGroup.interactable = false;
        InGameMenuCanvasGroup.blocksRaycasts = false;
    }
}
