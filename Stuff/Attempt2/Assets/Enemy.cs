using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy : MonoBehaviour
{
    public Vector3 direction;
    public Player player;

    public bool chasingPlayer = true;
    public float speed = 3.5f;
    public float distanceToStop = 1f;

    public float eatingInterval = 0.5f;
    private float eatingTimer = 0f;

    public int damage = 3;

    public float enemyHP = 5f;

    private float timer;
    public float gazeTimer = 2f;
    private bool gazedAt;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if(timer >= gazeTimer)
            {
                Destroy(this.gameObject);
                player.points += 1;
            }
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToStop)
        {
            chasingPlayer = false;
        }

        if (chasingPlayer)
        {
            transform.position += 0.5f * (direction * speed * Time.deltaTime);
        }
        else
        {
            eatingTimer -= Time.deltaTime;
            if (eatingTimer <= 0f)
            {
                eatingTimer = eatingInterval;
                player.health -= damage;
            }
        }
    }

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }

}
