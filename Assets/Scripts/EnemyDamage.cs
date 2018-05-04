using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	[SerializeField] Collider collisionMesh;
	[SerializeField] int hitPoints = 500;

	[SerializeField] ParticleSystem deathParticlePrefab;
	[SerializeField] ParticleSystem sparksParticlePrefab;
	[SerializeField] ParticleSystem detonateParticlePrefab;

	[SerializeField] AudioClip deathSFX;
	[SerializeField] AudioClip sparksSFX;
	[SerializeField] AudioClip detonateSFX;

	AudioSource myAudioSource;

	void Start() 
	{
		AddBoxCollider();
		myAudioSource = GetComponent<AudioSource>();
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
		Invoke("MuteAudio", 1f);	
	}

    private void ProcessHits()
    {		
		sparksParticlePrefab.Play();
		myAudioSource.mute = false;
		hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
		float volume = .05f;
		// played from camera's position because spacial blend is automatically set to 3D instead of 2D
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volume); 

		var deathFX = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
		deathFX.Play();	
		float destroyDelay = deathFX.main.duration;

		Destroy(deathFX.gameObject, destroyDelay);
		Destroy(gameObject);
		
    }

	public void DetonateEnemy()
	{
		AudioSource.PlayClipAtPoint(detonateSFX, transform.position);
		var detonateFX = Instantiate(detonateParticlePrefab, transform.position, Quaternion.identity);
		detonateFX.Play();
		float destroyDelay = detonateFX.main.duration;
		Destroy(detonateFX.gameObject, destroyDelay);	
		Destroy(gameObject);	
	}

	void MuteAudio()
	{
		myAudioSource.mute = true;
	}
}
