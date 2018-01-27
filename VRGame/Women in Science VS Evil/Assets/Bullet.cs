using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;
    public Vector3 direction;
    public float lifetime = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * speed * Time.deltaTime;

        lifetime -= Time.deltaTime;
        if(lifetime <= 0f)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null)
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

    }
}
