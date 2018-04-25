using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;

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
		Pathfind();

		// ExploreNeighbours();
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

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

		while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
        }
		print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stoppping"); // TODO remove later
			isRunning = false;
        }
    }
}
