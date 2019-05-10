/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public Vector2 minPosition;
    public Vector2 maxPosition;
}

public class Pilot : MonoBehaviour
{
    public Boundary boundary;
    public float manuverSpeed = 5f;

    Rigidbody2D rb;

	void Start ()
	{
        if(rb == null)
        {
            rb = GetComponentInChildren<Rigidbody2D>();
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
        }
	}
	
	void FixedUpdate ()
	{
        float hManuver = Input.GetAxis("Horizontal");
        float vManuver = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(hManuver, vManuver);

        // Moving Player simply with arrow key
        //rb.velocity = movement * manuverSpeed;

        // Moving Player towards mouse click position
        if(Input.GetMouseButton(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (clickPos - transform.position).normalized;

            rb.velocity = new Vector2(direction.x * manuverSpeed, direction.y * manuverSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        // Clamping Player's Position
        rb.position = new Vector2
            (
                Mathf.Clamp(transform.position.x, boundary.minPosition.x, boundary.maxPosition.x),
                Mathf.Clamp(transform.position.y, boundary.minPosition.y, boundary.maxPosition.y)
            );
	}

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hazards")
        {
            Debug.Log("Collides With Hazard!");
        }
    }
}
