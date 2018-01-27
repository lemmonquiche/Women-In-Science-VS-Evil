using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class WatCrickAnim : MonoBehaviour {

    public float gazeTimer = 3f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gazed()
    {
        gazeTimer -= Time.deltaTime;

        if(gazeTimer <= 0)
        {
            Destroy(GetComponent<Collider>().gameObject);
        }
    }

    public void ungaze()
    {
       
    }
}
