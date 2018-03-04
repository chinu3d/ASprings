using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFlyingObjectScript : MonoBehaviour {

    public GameObject endPoint;
    public float speed;
    public bool currentlyActive = false;

    private Transform _myTransform;
    private Vector2 _endPointPos;

    // Use this for initialization
    void Start () {

        //this.transform.Translate(new Vector3(-1.0f, 0.0f, 0.0f));
        _myTransform = this.gameObject.transform;
        _endPointPos = this.endPoint.transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (this.currentlyActive)
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, _endPointPos, speed * Time.deltaTime);
        }
    }
}
