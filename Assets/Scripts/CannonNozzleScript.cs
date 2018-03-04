using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonNozzleScript : MonoBehaviour {

    public SpriteRenderer cannonNozzleFire;
    public GameObject dustCloud;
    public GameObject cannonNozzleMouth;
    public GameObject cannonBall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator fireCannonBall()
    {
        cannonNozzleFire.enabled = true;
        GameObject tempDustCloud = GameObject.Instantiate(this.dustCloud, this.cannonNozzleMouth.transform.position, this.cannonNozzleMouth.transform.rotation);
        GameObject.Destroy(tempDustCloud, 1.0f);

        GameObject tempCannonBall = GameObject.Instantiate(this.cannonBall, this.cannonNozzleMouth.transform.position, this.cannonNozzleMouth.transform.rotation);
        tempCannonBall.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(800.0f, 0.0f, 0.0f));
        GameObject.Destroy(tempCannonBall, 10.0f);

        //Wait for some time and then, hide the nozzle fire
        yield return new WaitForSeconds(0.1f);
        cannonNozzleFire.enabled = false;
    }
}
