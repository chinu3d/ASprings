﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonWheelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void cannonWheelRotate(float angle)
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), angle);
    }

}
