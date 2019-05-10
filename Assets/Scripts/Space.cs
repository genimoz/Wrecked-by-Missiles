/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeY;

    Vector3 startPosition;

	void Start ()
	{
        startPosition = transform.position;
	}
	
	void Update ()
	{
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
	}
}
