using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArc : MonoBehaviour {

    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start () {

        _rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(this.gameObject.transform.eulerAngles.z);

        float angleOfRotation = Mathf.Abs(this.gameObject.transform.eulerAngles.z);

        if ((angleOfRotation <= 182.0f) && (angleOfRotation >= 178.0f))
        {
            _rigidBody.angularVelocity = 0.0f;
            StartCoroutine(this.wait());
        }
        else
        {
            _rigidBody.angularVelocity = -50.0f;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f), 0.1f);
    }
}
