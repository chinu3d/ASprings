using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AmmoSpawnerState
{
    ReadyForNextSpawn,
    NotReadyForSpawn,
}


public class AmmoSpawnerScript : MonoBehaviour {

    public GameObject ammoPrefab;
    public int maxAmmo;

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
        if ((collision.gameObject.tag.Equals("Projectile")) && (arrayOfProjectileNamesExhaustedSoFar.Contains(collision.gameObject.name) == false))
        {
            _ammoSpawnerState = AmmoSpawnerState.ReadyForNextSpawn;
        }

        if (collision.gameObject.tag.Equals("Projectile")) 
            arrayOfProjectileNamesExhaustedSoFar.Add(collision.gameObject.name);
    }
}
