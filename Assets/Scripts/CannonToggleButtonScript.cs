using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CannonToggleButtonScript : MonoBehaviour {

    public CannonScript cannonScript;

    private Image sourceImage;

    public Sprite translateSprite;
    public Sprite rotateNozzleSprite;

    // Use this for initialization
    void Start () {

        GetComponent<Button>().onClick.AddListener(clicked);
        EventSystem.current.SetSelectedGameObject(null);

        this.sourceImage = GetComponent<Image>();
    }

    void clicked()
    {
        EventSystem.current.SetSelectedGameObject(null);
        CannonControlState newState = cannonScript.cannonControlStateToggled();

        if (newState == CannonControlState.Translate)
        {
            sourceImage.sprite = translateSprite;
        }
        else if (newState == CannonControlState.RotateNozzle)
        {
            sourceImage.sprite = rotateNozzleSprite;
        }
    }

    // Update is called once per frame
    void Update () {

        if ((GameManager.instance.currentPlatform == CurrentPlatform.Windows) ||
            (GameManager.instance.currentPlatform == CurrentPlatform.AppleOSX))
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                EventSystem.current.SetSelectedGameObject(null);
                CannonControlState newState = cannonScript.cannonControlStateToggled();

                if (newState == CannonControlState.Translate)
                {
                    sourceImage.sprite = translateSprite;
                }
                else if (newState == CannonControlState.RotateNozzle)
                {
                    sourceImage.sprite = rotateNozzleSprite;
                }

            }
        }

    }
}
