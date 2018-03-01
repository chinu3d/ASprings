using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CannonControlState
{
    Translate,
    RotateNozzle
}

public class CannonScript : MonoBehaviour {

    public float forceScale = 100.0f;
    public CannonWheelScript cannonWheel;
    public CannonNozzleScript cannonNozzleScript;
    public GameObject cannonNozzle;

    private Rigidbody2D _rigidBody;
    private CannonControlState cannonControlState;
    private float zRotationOfNozzle = 0.0f;

    // Use this for initialization
    void Start () {

        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if ((GameManager.instance.currentPlatform == CurrentPlatform.Windows) ||
            (GameManager.instance.currentPlatform == CurrentPlatform.AppleOSX))
        {
            float movementX = Input.GetAxis("Horizontal");
 
            if (cannonControlState == CannonControlState.Translate)
            {
                _rigidBody.AddForce(new Vector2(movementX * 10.0f * forceScale, 0.0f));
            }
            else if (cannonControlState == CannonControlState.RotateNozzle)
            {
                zRotationOfNozzle += movementX;

                if ((zRotationOfNozzle <= 40.0f) &&
                    (zRotationOfNozzle >= 0.0f))
                {
                    cannonNozzle.transform.eulerAngles = new Vector3(0.0f, 0.0f, zRotationOfNozzle);
                }

                if (zRotationOfNozzle < 0.0f)
                {
                    zRotationOfNozzle = 0.0f;
                }

                if (zRotationOfNozzle > 40.0f)
                {
                    zRotationOfNozzle = 40.0f;
                }
            }

        }
        else if ((GameManager.instance.currentPlatform == CurrentPlatform.iOS) ||
                 (GameManager.instance.currentPlatform == CurrentPlatform.Android))
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                if (cannonControlState == CannonControlState.Translate)
                {
                    _rigidBody.AddForce(new Vector2(touchDeltaPosition.x * forceScale, 0.0f));
                }
                else if (cannonControlState == CannonControlState.RotateNozzle)
                {
                    zRotationOfNozzle += Mathf.Clamp(touchDeltaPosition.x, -1.0f, 1.0f);

                    if ((zRotationOfNozzle <= 40.0f) &&
                        (zRotationOfNozzle >= 0.0f))
                    {
                        cannonNozzle.transform.eulerAngles = new Vector3(0.0f, 0.0f, zRotationOfNozzle);
                    }

                    if (zRotationOfNozzle < 0.0f)
                    {
                        zRotationOfNozzle = 0.0f;
                    }

                    if (zRotationOfNozzle > 40.0f)
                    {
                        zRotationOfNozzle = 40.0f;
                    }
                }
            }
        }

        //Set wheel rotation based on velocity
        if (Mathf.Abs(_rigidBody.velocity.x) > 0.0f)
        {
            this.cannonWheel.cannonWheelRotate(-(_rigidBody.velocity.x));
        }
    }

    public CannonControlState cannonControlStateToggled()
    {
        if (cannonControlState == CannonControlState.Translate)
        {
            cannonControlState = CannonControlState.RotateNozzle;
            return CannonControlState.RotateNozzle;
        }
        else if (cannonControlState == CannonControlState.RotateNozzle)
        {
            cannonControlState = CannonControlState.Translate;
            return CannonControlState.Translate;
        }

        return CannonControlState.Translate;
    }
}
