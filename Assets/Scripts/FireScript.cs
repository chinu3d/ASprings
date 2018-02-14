using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    private AudioSource _audioSource;

	// Use this for initialization
	void Start () {

        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<WoodenProjectileScript>() != null) ||
            (collision.gameObject.GetComponent<RocketProjectileScript>() != null))
        {
            GameObject.Destroy(collision.gameObject, 0.2f);

            if (this._audioSource.isPlaying == false)
            {
                this._audioSource.Play();
            }
        }
    }
}
