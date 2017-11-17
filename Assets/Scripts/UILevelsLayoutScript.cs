using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UILevelsLayoutScript : MonoBehaviour {

    public GameObject contentView;
    public VerticalLayoutGroup verticalLayoutGroupForLevelButtons;
    public float buttonHeight;
    public int numberOfButtons;

	// Use this for initialization
	void Start () {

        float height = -1 * (((verticalLayoutGroupForLevelButtons.spacing + buttonHeight) * (float)numberOfButtons) + verticalLayoutGroupForLevelButtons.padding.top);
        contentView.GetComponent<RectTransform>().offsetMin = new Vector2(contentView.GetComponent<RectTransform>().offsetMin.x, height);
    }
	
}
