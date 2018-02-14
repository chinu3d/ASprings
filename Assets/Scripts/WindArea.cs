using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

	public float strength;
	public Vector3 direction;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if ((collision.gameObject.tag.Equals("Projectile")) && (collision.gameObject.layer == 13))
		{

		}
		collision.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (direction.x * strength, direction.y * strength, 0.0f));
	}
}
