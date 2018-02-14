using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenProjectileScript : MonoBehaviour {

    private AudioSource _audioSource;
    private Animator _animator;

    // Use this for initialization
    void Start () {

        this._audioSource = GetComponent<AudioSource>();
        this._animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_audioSource != null) && (_audioSource.isPlaying == false))
            this._audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            this._animator.enabled = true;
        }
    }

}
