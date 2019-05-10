/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PansBoundary
{
    public Vector2 panLimitMin;
    public Vector2 panLimitMax;
}

public class Clamping : MonoBehaviour
{
	public PansBoundary pan;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		Vector2 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(transform.position.x, pan.panLimitMin.x, pan.panLimitMax.x);
		clampedPosition.y = Mathf.Clamp(transform.position.y, pan.panLimitMin.y, pan.panLimitMax.y);
		transform.position = clampedPosition;
	}
}
