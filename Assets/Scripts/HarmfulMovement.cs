/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float tumbleSpeed = 10f;

	void Start ()
	{
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
        rb.velocity = Vector2.down * tumbleSpeed;
	}

    private void Update()
    {
        Destroy(gameObject, 5f);
    }
}
