/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 50f;
	
	void Update ()
	{
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
	}
}
