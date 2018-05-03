using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{

	[SerializeField] float secondsBetweenSpawns= 5f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] GameObject enemyParent;
	[SerializeField] PlayerHealth playerHealth;

	void Start() 
	{
		StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
		while(playerHealth.health.CurrentVal > 0) 
		{
			var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParent.transform;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
    }
}
