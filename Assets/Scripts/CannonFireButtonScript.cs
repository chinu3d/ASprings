using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CannonFireButtonScript : MonoBehaviour {

    public CannonNozzleScript cannonNozzleScript;

    // Use this for initialization
    void Start () {

        if ((GameManager.instance.currentPlatform == CurrentPlatform.iOS) ||
            (GameManager.instance.currentPlatform == CurrentPlatform.Android))
        {
            GetComponent<Button>().onClick.AddListener(clicked);
            EventSystem.current.SetSelectedGameObject(null);

            GetComponent<Image>().enabled = true;

        } else if ((GameManager.instance.currentPlatform == CurrentPlatform.Windows) ||
            (GameManager.instance.currentPlatform == CurrentPlatform.AppleOSX))
        {
            GetComponent<Image>().enabled = false;
        }
    }

    void clicked()
    {
        EventSystem.current.SetSelectedGameObject(null);

        StartCoroutine(cannonNozzleScript.fireCannonBall());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
