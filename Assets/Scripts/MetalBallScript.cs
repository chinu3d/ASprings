using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBallScript : MonoBehaviour {

    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {

        this._audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_audioSource != null) && (_audioSource.isPlaying == false))
            this._audioSource.Play();
    }
}
