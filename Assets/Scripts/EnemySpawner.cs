using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{

	[SerializeField] float secondsBetweenSpawns= 5f;
	[SerializeField] EnemyMovement enemyPrefab;

	Vector3 spawnLocation;

	void Start() 
	{
		StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
		while(true) // forever
		{
			print("spawning");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
    }
}
