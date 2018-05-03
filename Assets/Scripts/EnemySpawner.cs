using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour 
{

	[SerializeField] float secondsBetweenSpawns= 5f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] GameObject enemyParent;
	[SerializeField] PlayerHealth playerHealth;
	[SerializeField] Text enemyTally;
	
	int score;

	void Start() 
	{
		enemyTally.text = score.ToString();
		StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
		while(playerHealth.health.CurrentVal > 0)
        {
            AddScore();

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        enemyTally.text = score.ToString();
    }
}
