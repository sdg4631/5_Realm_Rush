using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Waypoint pathColor;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter; // current search center
	List<Waypoint> path = new List<Waypoint>();

	Vector2Int[] directions = 
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// For EnemyMovement
	public List<Waypoint> GetPath()
	{
		if(path.Count == 0)
        {
            CalculatePath();
        }
        return path;		
	}

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFristSearch();
        CreatePath();
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

	private void BreadthFristSearch()
    {
        queue.Enqueue(startWaypoint);

		while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
            HaltIfEndFound();
			ExploreNeighbours();
        }
		print("Finished BreadthFristSearching?");
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
			if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
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

	private void CreatePath()
    {
		SetAsPath(endWaypoint);
        		
		Waypoint previous = endWaypoint.exploredFrom;
		while ( previous != startWaypoint)
		{
			SetAsPath(previous);
			previous = previous.exploredFrom;
		}

		SetAsPath(startWaypoint);
		path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
		waypoint.isPlaceable = false;
		waypoint.SetPathTopColor();
    }
}
