using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBallScript : MonoBehaviour {

    public bool ballHasBeenDropped;

    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {

        this._audioSource = GetComponent<AudioSource>();
        this.ballHasBeenDropped = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_audioSource != null) && (_audioSource.isPlaying == false))
            this._audioSource.Play();
    }
}
