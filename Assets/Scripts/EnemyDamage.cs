using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	[SerializeField] Collider collisionMesh;
	[SerializeField] ParticleSystem explosionParticlePrefab;
	[SerializeField] ParticleSystem sparksParticlePrefab;
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
		sparksParticlePrefab.Play();
		hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
		var explosionFX = Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);
		explosionFX.Play();	
		float destroyDelay = explosionFX.main.duration;
		Destroy(explosionFX.gameObject, destroyDelay);
		Destroy(gameObject);
		
    }
}
