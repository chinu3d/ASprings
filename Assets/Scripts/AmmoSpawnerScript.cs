using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum AmmoSpawnerState
{
    ReadyForNextSpawn,
    NotReadyForSpawn,
}


public class AmmoSpawnerScript : MonoBehaviour {

    public GameObject ammoPrefab;
    public int maxAmmo;
    public UnityEvent ammoFiredEvent;

    private int ammoExhaustedSoFar;
    private AmmoSpawnerState _ammoSpawnerState;
    private ArrayList arrayOfProjectileNamesExhaustedSoFar = new ArrayList();
    
	// Use this for initialization
	void Start () {

        ammoExhaustedSoFar = 1;
        _ammoSpawnerState = AmmoSpawnerState.NotReadyForSpawn;

        GameObject tempProjectileObject = GameObject.Instantiate(ammoPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        tempProjectileObject.name = "Projectile_" + ammoExhaustedSoFar;
        //arrayOfProjectileNamesExhaustedSoFar.Add(tempProjectileObject.name);
    }
	
	public void createNewAmmo()
    {
        if ((ammoExhaustedSoFar < maxAmmo) && (_ammoSpawnerState == AmmoSpawnerState.ReadyForNextSpawn))
        {
            GameObject tempProjectileObject = GameObject.Instantiate(ammoPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            ammoExhaustedSoFar += 1;
            tempProjectileObject.name = "Projectile_" + ammoExhaustedSoFar;
            //arrayOfProjectileNamesExhaustedSoFar.Add(tempProjectileObject.name);

            _ammoSpawnerState = AmmoSpawnerState.NotReadyForSpawn;
        }
    }

    public int ammoLeft()
    {
        return (maxAmmo - ammoExhaustedSoFar);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag.Equals("Projectile")) && 
            (collision.gameObject.layer == 13) &&
            (arrayOfProjectileNamesExhaustedSoFar.Contains(collision.gameObject.name) == false))
        {
            collision.gameObject.layer = 12; //Layer no. 12 is "Interactible". This has been done so that as soon as it has been fired, it should be affected by other activities such as explosions etc.
            this.ammoFiredEvent.Invoke();
            _ammoSpawnerState = AmmoSpawnerState.ReadyForNextSpawn;
        }

        if ((collision.gameObject.tag.Equals("Projectile")) &&
            (collision.gameObject.layer == 13))
        {
            arrayOfProjectileNamesExhaustedSoFar.Add(collision.gameObject.name);
        }
    }
}
