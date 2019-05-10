/*
* Author : Genimoz
* Copyright (c) 2018 Patriano Genio
* All Rights Reserved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector2 spawnPoint;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public bool bigObstacle;

	void Start ()
    {
        if(bigObstacle)
        {
            StartCoroutine(SpawnPlanet());
        }
        else
        {
            StartCoroutine(SpawnObstacles());
        }
	}

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnPoint.x, spawnPoint.x), spawnPoint.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

        yield return new WaitForSeconds(waveWait);
    }

    IEnumerator SpawnPlanet()
    {
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPosition = new Vector2(spawnPoint.x, spawnPoint.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

        yield return new WaitForSeconds(waveWait);
    }
}
