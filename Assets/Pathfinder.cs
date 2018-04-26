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
	Waypoint searchCenter; // current search center

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
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
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

	private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
            HaltIfEndFound();
			ExploreNeighbours();
        }
		// TODO workout pathfinding
		print("Finished pathfinding?");
    }

	private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
			isRunning = false;
        }
    }

	private void ExploreNeighbours()
    {
		if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
		{
			Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
			try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
			{
				// do nothing
			}
			
		}
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
		Waypoint neighbour = grid[neighbourCoordinates];
		if(neighbour.isExplored || queue.Contains(neighbour))
		{
			// do nothing
		}
		else
		{      	
        	queue.Enqueue(neighbour);
			neighbour.exploredFrom = searchCenter;
		}
        
    }
}
