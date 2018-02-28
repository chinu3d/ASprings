using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CannonToggleButtonScript : MonoBehaviour {

    public CannonScript cannonScript;

    private Image sourceImage;

    public Sprite translateSprite;
    public Sprite rotateNozzleSprite;

    // Use this for initialization
    void Start () {

        GetComponent<Button>().onClick.AddListener(clicked);

        this.sourceImage = GetComponent<Image>();
    }

    void clicked()
    {
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
		
	}
}
