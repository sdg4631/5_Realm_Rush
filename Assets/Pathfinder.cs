using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Vector2Int[] directions = 
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	void Start()
	{
		LoadBlocks();
		ColorStartAndEnd();
		ExploreNeighbours();
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
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.white);
		endWaypoint.SetTopColor(Color.black);
    }

	    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
		{
			Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
			try
			{
				grid[explorationCoordinates].SetTopColor(Color.blue);
			}
			catch
			{
				// do nothing
			}
			
		}
    }
}
