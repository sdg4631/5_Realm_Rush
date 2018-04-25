using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	void Start()
	{
		LoadBlocks();
	}

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			// overlapping blocks?
			var gridPos = waypoint.GetGridPos();
			bool isOverlapping = grid.ContainsKey(gridPos);
			if (isOverlapping)
			{
				Debug.LogWarning("Skipping overlapping block " + waypoint);
			}
			else
			{
				// add to dictionary
				grid.Add(gridPos, waypoint);
			}			
		}
		print("Loaded " + grid.Count + " blocks");
    }

    void Update()
	{
		
	}
}
