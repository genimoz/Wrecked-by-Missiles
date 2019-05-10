/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform controller;
    public float chaseSpeed = 10f;
    public float rotateSpeed = 100f;

    public GameObject destroyedFX;

    public Vector3 offset = new Vector3(0, 15.5f, 0f);

    private Rigidbody2D rb;
    private GameObject airshipGO;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GameObject.FindGameObjectWithTag("Controller").transform;
        airshipGO = transform.Find("Airship").gameObject;
        //controller.position = new Vector3(0, 10, 0); // Reset position of the controller
    }

    void Update()
    {
        // Transform stuff
        transform.position = Vector2.Lerp(transform.position, controller.position, chaseSpeed);

        Vector3 difference = controller.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        // Player's Attributes
        if(GameManager.instance.playerLife <= 0)
        {
            GameManager.instance.isGameEnded = true;

            Destroy(gameObject);
            destroyedFX = (GameObject)Instantiate(Resources.Load("AirshipDestroyedFX"), transform.position, Quaternion.identity);
            Destroy(destroyedFX, 0.5f);

            //GameManager.instance.PickHighscore();
        }
    }

   
}
