using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{

	[SerializeField] float secondsBetweenSpawns= 5f;
	[SerializeField] EnemyMovement enemyPrefab;

	void Start() 
	{
		StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
		while(true) // forever
		{
			Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
    }
}
