using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectileScript : MonoBehaviour {

    public GameObject explosion;

    private AudioSource _audioSource;
    private bool _hasLeftAmmoSpawner;

    // Use this for initialization
    void Start()
    {

        this._audioSource = GetComponent<AudioSource>();
        _hasLeftAmmoSpawner = false;
    }

    void Update()
    {
        //wait();
        if (_hasLeftAmmoSpawner)
        {
            //float rotatedAngle = this.gameObject.transform.rotation.z;
            this.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(10.0f, 0.0f, 0.0f));
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_audioSource != null) && (_audioSource.isPlaying == false))
        {
            this._audioSource.Play();

            if (_hasLeftAmmoSpawner)
            {
                GameObject tempExplosion = Instantiate(explosion, transform.position, transform.rotation);
                GameObject.DestroyObject(tempExplosion, 1.5f);
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("AmmoSpawner"))
        {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

            AudioSource rocketExhaustAudioSource = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
            if (rocketExhaustAudioSource.isPlaying == false)
                rocketExhaustAudioSource.Play();

            _hasLeftAmmoSpawner = true;
        }
    }

}
