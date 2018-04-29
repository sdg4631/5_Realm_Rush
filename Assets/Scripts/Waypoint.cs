﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
	// public is ok here as is a data class
	public bool isExplored = false; 
	public Waypoint exploredFrom;
	public bool isPlaceable = true;
	
	const int gridSize = 10;

	Vector2Int gridPos;

	void Update()
	{
		
	}
	
	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int
		(
			Mathf.RoundToInt(transform.position.x / gridSize),
       		Mathf.RoundToInt(transform.position.z / gridSize)
		);	
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0)) // left click
		{
			if (isPlaceable)
			{
				Debug.Log("Tower placed at: " + gameObject.name);
			}
			else
			{
				print("Not placeable here");
			}
		}	
	}
}
