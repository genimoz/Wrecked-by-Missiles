/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float speed = 10f;

	void Start ()
	{
		
	}
	
	void Update ()
	{
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}
}
