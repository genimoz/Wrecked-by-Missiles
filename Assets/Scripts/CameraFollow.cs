/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;

    Transform rocket;

	void Start ()
	{
        rocket = GameObject.FindGameObjectWithTag("Rocket").transform;
	}
	
	void LateUpdate ()
	{
        transform.position = rocket.position + offset;
	}
}
