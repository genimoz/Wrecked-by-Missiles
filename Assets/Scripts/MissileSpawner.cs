/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public float timeBetweenSpawn = 2f;
    public float spawnWait = 1;

    Transform spawnPoint;

	void Start ()
	{
        spawnPoint = this.transform;

        InvokeRepeating("SpawningMissile", spawnWait, timeBetweenSpawn);
	}
	
	void Update ()
	{

	}

    void SpawningMissile()
    {
        GameObject missile = (GameObject)Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
