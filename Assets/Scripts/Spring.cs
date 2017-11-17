using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    public Rigidbody2D attachedLoad;
    public Transform StartPointOfPermissibleLoadLimit;
    public Transform EndPointOfPermissibleLoadLimit;
    public Transform SpringHinge;

    private float slopeOfPlatform;
    private Renderer _renderer;
    private float initialWidthOfSpring;
    private float initialXScaleOfSpring;
    private Vector2 initialPosition;

    // Use this for initialization
    void Start () {

        slopeOfPlatform = (EndPointOfPermissibleLoadLimit.position.y - StartPointOfPermissibleLoadLimit.position.y) /
            (EndPointOfPermissibleLoadLimit.position.x - StartPointOfPermissibleLoadLimit.position.x);

        _renderer = this.GetComponent<Renderer>();
        initialWidthOfSpring = _renderer.bounds.size.x;
        initialXScaleOfSpring = transform.localScale.x;
        initialPosition = new Vector2(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {

        float newWidthOfSpringRequired = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((attachedLoad.transform.position.x - SpringHinge.position.x), 2.0f) + Mathf.Pow((attachedLoad.transform.position.y - SpringHinge.position.y), 2.0f)));
        float d = (newWidthOfSpringRequired - initialWidthOfSpring)/2.0f;

        this.transform.localScale = new Vector2(initialXScaleOfSpring * (newWidthOfSpringRequired / initialWidthOfSpring), transform.localScale.y);
        this.transform.position = new Vector2(initialPosition.x + (d / Mathf.Sqrt(1.0f + Mathf.Pow(slopeOfPlatform, 2.0f))),
            initialPosition.y + slopeOfPlatform * (d / Mathf.Sqrt(1.0f + Mathf.Pow(slopeOfPlatform, 2.0f))));
    }
}
