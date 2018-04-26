using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
	[SerializeField] Color exploredColor;

	// public is ok here as is a data class
	public bool isExplored = false; 
	public Waypoint exploredFrom;
	
	const int gridSize = 10;

	Vector2Int gridPos;

	void Update()
	{
		// TODO remove later
		if (isExplored)
		{
			SetTopColor(exploredColor);
		}
		else
		{
			// do nothing
		}

		
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

	public void SetTopColor(Color color) 
	{
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;	    
	}
}
