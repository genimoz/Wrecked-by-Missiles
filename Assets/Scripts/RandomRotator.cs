/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float radius = 5f;
    public float rotateSpeed = 10f;

    void Start()
    {
        //GetComponent<Rigidbody2D>().angularVelocity = Random.insideUnitCircle.x * radius;

        // Get random value of rotating speed
        rotateSpeed = Random.Range(-rotateSpeed, rotateSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * (rotateSpeed * 100) * Time.deltaTime);
    }
}
