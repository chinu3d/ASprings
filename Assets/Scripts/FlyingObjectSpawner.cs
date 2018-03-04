using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectSpawner : MonoBehaviour {

    public GameObject zeppelin;
    public GameObject endPoint;

	// Use this for initialization
	void Start () {

        GameObject tempZeppelin = GameObject.Instantiate(zeppelin, this.transform.position, this.transform.rotation);
        tempZeppelin.GetComponent<StraightFlyingObjectScript>().currentlyActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
