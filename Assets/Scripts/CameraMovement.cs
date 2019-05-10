/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PanBoundary
{
    public Vector2 panLimitMin;
    public Vector2 panLimitMax;
}

public class CameraMovement : MonoBehaviour
{
	public PanBoundary pan;
	
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate ()
	{
		FollowTarget();

		if (transform.position.x >= pan.panLimitMax.x || transform.position.x <= pan.panLimitMin.x)
		{
			Clamping();
		}
		if (transform.position.y >= pan.panLimitMax.y || transform.position.y <= pan.panLimitMin.y)
		{
			Clamping();
		}
	}

	void FollowTarget()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = desiredPosition;

		transform.LookAt(target);
	}

	void Clamping()
	{		
		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(target.position.x, pan.panLimitMin.x, pan.panLimitMax.x);
		clampedPosition.y = Mathf.Clamp(target.position.y, pan.panLimitMin.y, pan.panLimitMax.y);
		clampedPosition.z = transform.position.z;
		transform.position = clampedPosition;
	}
}
