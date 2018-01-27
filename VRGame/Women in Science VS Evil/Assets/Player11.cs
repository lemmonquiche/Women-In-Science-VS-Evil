using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player11 : MonoBehaviour {

    public int health = 100;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = this.transform.position;

            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.direction = transform.forward;
        }


    }
}
