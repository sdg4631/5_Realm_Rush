using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] public Stat health;
	[SerializeField] ParticleSystem baseExplosionParticlePrefab;
	[SerializeField] float decreaseHealthDelay = 1f;

	private void Awake()
	{
		health.Initialize();
	}

	void Update()
	{
		BaseExplosion();
	}

	void OnTriggerEnter()
	{	
		Invoke("DecreaseHealth", decreaseHealthDelay);		
	}

	void BaseExplosion()
	{
		Vector3 temp = new Vector3(0, 15, 0);
		var explosionPos = transform.position + temp;

		if(health.CurrentVal < 1)
		{
			var baseExplosionFX = Instantiate(baseExplosionParticlePrefab, explosionPos, Quaternion.identity);
			baseExplosionFX.Play();
			float destroyDelay = 5f;
			Destroy(baseExplosionParticlePrefab.gameObject, destroyDelay);
			Destroy(gameObject);
		}		
	}

	void DecreaseHealth()
	{
		health.CurrentVal -= 10;
	}
}
