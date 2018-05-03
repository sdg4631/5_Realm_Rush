using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	[SerializeField] Collider collisionMesh;
	[SerializeField] ParticleSystem explosionParticlePrefab;
	[SerializeField] ParticleSystem sparksParticlePrefab;
	[SerializeField] ParticleSystem detonateParticlePrefab;
	[SerializeField] int hitPoints = 500;
	
	
	void Start() 
	{
		AddBoxCollider();
	}

	void Update()
	{
		var playerBase = FindObjectOfType<PlayerHealth>();
		if (!playerBase)
		{
			DetonateEnemy();
		}
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

	public void DetonateEnemy()
	{
		var detonateFX = Instantiate(detonateParticlePrefab, transform.position, Quaternion.identity);
		detonateFX.Play();
		float destroyDelay = detonateFX.main.duration;
		Destroy(detonateFX.gameObject, destroyDelay);	
		Destroy(gameObject);	
	}
}
