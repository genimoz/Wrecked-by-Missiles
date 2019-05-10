/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    public GameObject player;
    public float chaseSpeed = 10f;
    public float rotateSpeed = 100f;

    public GameObject explosionParticle;

    Transform target;

    private Rigidbody2D rb;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        rb = GetComponent<Rigidbody2D>();
        //explosionParticle = Resources.Load("Explosion", typeof(GameObject)) as GameObject;
    }
	
	void FixedUpdate ()
	{
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotateForce =  Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateForce * rotateSpeed;
        rb.velocity = transform.up * chaseSpeed;

	}

    private void Update()
    {
        if(target == null || player == null)
        {
            this.enabled = false;
            Destroy(gameObject);
            explosionParticle = (GameObject)Instantiate(Resources.Load("Explosion", typeof(GameObject)), transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            GameManager.instance.playerScore += 1;

            Destroy(gameObject);
            explosionParticle = (GameObject)Instantiate(Resources.Load("Explosion", typeof(GameObject)), transform.position, Quaternion.identity);
            Destroy(explosionParticle, 0.75f);
        }
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.playerLife -= 1;

            Destroy(gameObject);
            explosionParticle = (GameObject)Instantiate(Resources.Load("Explosion", typeof(GameObject)), transform.position, Quaternion.identity);
            Destroy(explosionParticle, 0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dodge")
        {
            GameManager.instance.playerScore += 1;
            StartCoroutine("Dodging");
        }
    }

    IEnumerator Dodging()
    {
        target = player.transform;

        target.localScale = new Vector2(target.localScale.x, 2.75f);
        yield return new WaitForSeconds(0.25f);
        target.localScale = new Vector2(target.localScale.x, 3.5f);
    }
}
