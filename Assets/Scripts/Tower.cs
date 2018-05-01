﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour 
{
	[SerializeField] Transform objectToPan;
	[SerializeField] float attackRange = 30f;
	[SerializeField] ParticleSystem projectileParticle;

	public Waypoint baseWaypoint; //what the tower is standing on

	// State of each tower
	Transform targetEnemy;
	

	void Start()
	{
		
	}

	void Update() 
	{
		SetTargetEnemy();
		if(targetEnemy)
		{
			objectToPan.LookAt(targetEnemy);
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}		
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
		if (sceneEnemies.Length == 0) { return; }

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyDamage testEnemy in sceneEnemies)
		{
			closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
		}

		targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
		var distanceToA = Vector3.Distance(transform.position, transformA.position);
		var distanceToB = Vector3.Distance(transform.position, transformB.position);
		if(distanceToA < distanceToB)
		{
			return transformA;
		}
		else
		{
			return transformB;
		}
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if(distanceToEnemy <= attackRange)
		{
			Shoot(true);
		}
		else
		{
			Shoot(false);
		}
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
    }
}
