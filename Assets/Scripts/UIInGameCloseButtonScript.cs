using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGameCloseButtonScript : MonoBehaviour
{
    public CanvasGroup InGameMenuCanvasGroup;


    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    void clicked()
    {
        if (InGameMenuCanvasGroup.interactable == false)
        {
            //Pause the game
            GameManager.instance.pauseGame();
            showInGameMenu();
        }
        else
        {
            //Resume the game
            GameManager.instance.resumeGame();
            hideInGameMenu();
        }
    }

    void showInGameMenu()
    {
        InGameMenuCanvasGroup.alpha = 1f;
        InGameMenuCanvasGroup.interactable = true;
        InGameMenuCanvasGroup.blocksRaycasts = true;
    }

    void hideInGameMenu()
    {
        InGameMenuCanvasGroup.alpha = 0f;
        InGameMenuCanvasGroup.interactable = false;
        InGameMenuCanvasGroup.blocksRaycasts = false;
    }
}