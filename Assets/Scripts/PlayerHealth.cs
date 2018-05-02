using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] int playerHitPoints = 10;
	[SerializeField] ParticleSystem baseExplosionParticlePrefab;

	void OnTriggerEnter()
	{
		playerHitPoints--;
		if(playerHitPoints <= 0)
		{
			BaseExplosion();
		}
	}

	void BaseExplosion()
	{
		var baseExplosionFX = Instantiate(baseExplosionParticlePrefab, transform.position, Quaternion.identity);
		baseExplosionFX.Play();
		float destroyDelay = 5f;
		Destroy(baseExplosionParticlePrefab.gameObject, destroyDelay);
		Destroy(gameObject);
	}

}
