using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksScript : MonoBehaviour {

    public GameObject[] arrayOfFireworkPrefabs;
    public GameObject[] arrayOfFireworkSources;

    private float timeSinceLastFirework = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Do every 0.9 secs
        if (Time.time - this.timeSinceLastFirework >= 0.5f)
        {
            int randomNumForChoosingFireworkPrefab = (int)(Random.Range(0.0f, (float)(arrayOfFireworkPrefabs.Length - 1)));
            int randomNumForChoosingFireworkSource = (int)(Random.Range(0.0f, (float)(arrayOfFireworkSources.Length - 1)));

            GameObject newFirework = GameObject.Instantiate((GameObject)(arrayOfFireworkPrefabs[randomNumForChoosingFireworkPrefab]), ((GameObject)arrayOfFireworkSources[randomNumForChoosingFireworkSource]).transform.position, ((GameObject)arrayOfFireworkSources[randomNumForChoosingFireworkSource]).transform.rotation);
            this.timeSinceLastFirework = Time.time;
            GameObject.Destroy(newFirework, 1.0f);
        }

    }
}
