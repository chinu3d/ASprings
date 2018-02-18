using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

	public float strength;
    //public Vector3 direction;

    private Vector3 direction;

    void Start()
    {
        //float angleOfRotationAboutZ = this.transform.rotation.z;
        float angleOfRotationAboutZ = (Mathf.PI/2.0f) - this.transform.rotation.z;
        this.direction = new Vector3(Mathf.Cos(angleOfRotationAboutZ), Mathf.Sin(angleOfRotationAboutZ), 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Projectile"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(direction.x * strength, direction.y * strength, 0.0f));
        }
    }

}
