using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderScript : MonoBehaviour {

    public GameObject explosion;
    
	// Use this for initialization
	void Start () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject tempExplosion = Instantiate(explosion, transform.position, transform.rotation);
        GameObject.DestroyObject(tempExplosion, 1.5f);
        gameObject.SetActive(false);
    }
}
