/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

[System.Serializable]
public class Boundary
{
    public Vector2 moveLimitMin;
    public Vector2 moveLimitMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;

    public float moveSpeed = 5f;
    
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float horizontal = CnInputManager.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = CnInputManager.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal, vertical, 0f);

        Vector2 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(transform.position.x, boundary.moveLimitMin.x, boundary.moveLimitMax.x);
        clampPosition.y = Mathf.Clamp(transform.position.y, boundary.moveLimitMin.y, boundary.moveLimitMax.y);
        transform.position = clampPosition;
    }
}
