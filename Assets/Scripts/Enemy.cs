using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int enemyHealth = 500;
	


	void Start() 
	{
		AddBoxCollider();
	}

	void Update()
	{
		print(enemyHealth);
	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
    }

	void OnParticleCollision(GameObject other)
	{
		ProcessHits();
		if (enemyHealth <= 0)
		{
			KillEnemy();
		}
		
	}

    private void ProcessHits()
    {
		enemyHealth = enemyHealth - 1;
        print("Hit!");
    }

    private void KillEnemy()
    {
		// TODO find a way to make explosion independent of enemy movement script
		
		deathFX.SetActive(true);	
		Destroy(this.gameObject);
		
    }
}
