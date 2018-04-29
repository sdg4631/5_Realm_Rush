using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	[SerializeField] Collider collisionMesh;
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int hitPoints = 500;
	


	void Start() 
	{
		AddBoxCollider();
	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
    }

	void OnParticleCollision(GameObject collisionMesh)
	{
		ProcessHits();
		if (hitPoints <= 0)
		{
			KillEnemy();
		}
		
	}

    private void ProcessHits()
    {
		hitPoints = hitPoints - 1;
        print("Current hitpoints: " + hitPoints); // TODO remove
    }

    private void KillEnemy()
    {
		// TODO find a way to make explosion independent of enemy movement script
			
		Destroy(gameObject);
		
    }
}
