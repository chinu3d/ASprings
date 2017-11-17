using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpringState
{
    AtRest,
    ReadyForRelease,
    Oscillating
}

public class SpringLoad : MonoBehaviour {

    public Transform StartPointOfPermissibleLoadLimit;
    public Transform EndPointOfPermissibleLoadLimit;
    public Transform SpringDragLoadLimit;
    public float springConstant;
    public float yCorrectionOfLoad;
    public float minimumDragDistanceForSpringToAct;

    private SpringState _springState;
    private Rigidbody2D _rigidBody;
    private float _massOfRigidBody;
    private Vector2 meanPositionOfLoad;
    private float angleThatThePlatformMakesWithTheXAxis;
    private float amplitudeStart;
    private Vector2 directionOfForce;
    private int numberOfTimesToAndFroHasHappened;
    private float slopeOfPlatform;


    // Use this for initialization
    void Start () {

        _springState = SpringState.AtRest;
        _rigidBody = GetComponent<Rigidbody2D>();
        _massOfRigidBody = _rigidBody.mass;
        meanPositionOfLoad = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        angleThatThePlatformMakesWithTheXAxis = Mathf.Atan2(EndPointOfPermissibleLoadLimit.position.y - StartPointOfPermissibleLoadLimit.position.y,
            EndPointOfPermissibleLoadLimit.position.x - StartPointOfPermissibleLoadLimit.position.x);
        slopeOfPlatform = (EndPointOfPermissibleLoadLimit.position.y - StartPointOfPermissibleLoadLimit.position.y) /
            (EndPointOfPermissibleLoadLimit.position.x - StartPointOfPermissibleLoadLimit.position.x);
    }
	
	// Update is called once per frame
	void Update () {
		
        if ((this._springState == SpringState.AtRest) || (this._springState == SpringState.ReadyForRelease))
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else if (this._springState == SpringState.Oscillating)
        {
            Vector2 tempDirectionOfForce = new Vector2(meanPositionOfLoad.x - this.gameObject.transform.position.x,
                meanPositionOfLoad.y - this.gameObject.transform.position.y);

            //Check if the new force has switched direction
            if (((tempDirectionOfForce.x <= 0) && (directionOfForce.x >= 0)) ||
                ((tempDirectionOfForce.x >= 0) && (directionOfForce.x <= 0)))
            {
                numberOfTimesToAndFroHasHappened += 1;
            }

            if (numberOfTimesToAndFroHasHappened > 4)
            {
                _rigidBody.velocity = Vector2.zero;
                this.gameObject.transform.position = meanPositionOfLoad;
                _rigidBody.AddForce(Vector2.zero);
                this._springState = SpringState.AtRest;
            }
            else
            {
                directionOfForce = new Vector2(tempDirectionOfForce.x, tempDirectionOfForce.y);
                directionOfForce.Normalize();

                float magnitudeOfForce = amplitudeStart * springConstant * _massOfRigidBody;
                _rigidBody.AddForce(new Vector2(magnitudeOfForce * directionOfForce.x, magnitudeOfForce * directionOfForce.y));
            }
        }
    }

    void OnMouseDrag() {

        if (GameManager.instance.gameIsPaused() == false)
        {
            if ((this._springState == SpringState.AtRest) || (this._springState == SpringState.ReadyForRelease))
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                point.z = gameObject.transform.position.z;

                if (point.x < meanPositionOfLoad.x)
                {
                    if (point.x > SpringDragLoadLimit.position.x)
                    {
                        gameObject.transform.position = new Vector2(point.x, StartPointOfPermissibleLoadLimit.position.y + (slopeOfPlatform * (point.x - StartPointOfPermissibleLoadLimit.position.x)) + yCorrectionOfLoad);
                        this._springState = SpringState.ReadyForRelease;
                    }
                    else
                    {
                        gameObject.transform.position = new Vector2(SpringDragLoadLimit.position.x, StartPointOfPermissibleLoadLimit.position.y + (slopeOfPlatform * (SpringDragLoadLimit.position.x - StartPointOfPermissibleLoadLimit.position.x)) + yCorrectionOfLoad);
                        this._springState = SpringState.ReadyForRelease;
                    }
                }
                else
                {
                    gameObject.transform.position = meanPositionOfLoad;
                    this._springState = SpringState.AtRest;
                }
            }
        }
    }

    private void OnMouseUp()
    {
        if (this._springState == SpringState.ReadyForRelease)
        {
            float draggedDistance = Mathf.Sqrt(Mathf.Pow((gameObject.transform.position.x - meanPositionOfLoad.x), 2.0f) + Mathf.Pow((gameObject.transform.position.y - meanPositionOfLoad.y), 2.0f));
            if (draggedDistance > minimumDragDistanceForSpringToAct)
            {
                this.numberOfTimesToAndFroHasHappened = 0;
                amplitudeStart = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((gameObject.transform.position.x - meanPositionOfLoad.x), 2.0f) + Mathf.Pow((gameObject.transform.position.y - meanPositionOfLoad.y), 2.0f)));
                this._springState = SpringState.Oscillating;
            }
            else
            {
                gameObject.transform.position = meanPositionOfLoad;
                this._springState = SpringState.AtRest;
            }
        }
    }
}
