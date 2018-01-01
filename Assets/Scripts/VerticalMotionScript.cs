using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VerticalMotionState
{
    MovingUp,
    MovingDown,
};

public class VerticalMotionScript : MonoBehaviour {

    public GameObject topPoint;
    public GameObject bottomPoint;
    public float speed;
    public VerticalMotionState verticalMotionState;

    private Rigidbody2D _rigidBody;
    private Transform _myTransform;
    private Vector2 _topPosition;
    private Vector2 _bottomPosition;

    // Use this for initialization
    void Start () {

        _rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        _myTransform = this.gameObject.transform;
        _topPosition = topPoint.transform.position;
        _bottomPosition = bottomPoint.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (this.gameObject.transform.position.y >= topPoint.transform.position.y)
        {
            verticalMotionState = VerticalMotionState.MovingDown;
        }
        else if (this.gameObject.transform.position.y <= bottomPoint.transform.position.y)
        {
            verticalMotionState = VerticalMotionState.MovingUp;
        }

        if (verticalMotionState == VerticalMotionState.MovingDown)
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, _bottomPosition, speed * Time.deltaTime);
        }
        else
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, _topPosition, speed * Time.deltaTime);
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
