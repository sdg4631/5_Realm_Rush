using System.Collections;
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
				FindObjectOfType<TowerFactory>().AddTower(this);
			}
			else
			{
				print("Not placeable here");
			}
		}	
	}

	public void SetPathTopColor()
	{
		float intensity = 2f;
		Material emissionColor = transform.Find("Top").GetComponent<Renderer>().material;
		emissionColor.SetColor("_EmissionColor", Color.blue * intensity);
		// MeshRenderer meshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		// meshRenderer.material.color = color;
		
	}
}
