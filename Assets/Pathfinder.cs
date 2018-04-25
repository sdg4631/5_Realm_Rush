using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	[SerializeField] Waypoint startWaypoint, endWaypoint;

	void Start()
	{
		LoadBlocks();
		ColorStartAndEnd();
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
}
