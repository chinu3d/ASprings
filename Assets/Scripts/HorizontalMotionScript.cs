using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HorizontalMotionState
{
    MovingLeft,
    MovingRight,
};

public class HorizontalMotionScript : MonoBehaviour {

    public GameObject leftPoint;
    public GameObject rightPoint;
    public float speed;
    public HorizontalMotionState horizontalMotionState;

    private Rigidbody2D _rigidBody;
    private Transform _myTransform;
    private Vector2 _leftPosition;
    private Vector2 _rightPosition;

    // Use this for initialization
    void Start()
    {

        _rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        _myTransform = this.gameObject.transform;
        _leftPosition = leftPoint.transform.position;
        _rightPosition = rightPoint.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.transform.position.x <= leftPoint.transform.position.x)
        {
            horizontalMotionState = HorizontalMotionState.MovingRight;
        }
        else if (this.gameObject.transform.position.x >= rightPoint.transform.position.x)
        {
            horizontalMotionState = HorizontalMotionState.MovingLeft;
        }

        if (horizontalMotionState == HorizontalMotionState.MovingRight)
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, _rightPosition, speed * Time.deltaTime);
        }
        else
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, _leftPosition, speed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.IsChildOf(this.transform))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
