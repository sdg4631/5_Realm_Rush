using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour 
{
	[SerializeField] Tower towerPrefab;
	[SerializeField] int towerLimit = 3;

	Queue<Tower> towerQueue = new Queue<Tower>();

	public void AddTower(Waypoint baseWaypoint)
	{
		int numberOfTowers = towerQueue.Count;

		if(numberOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

		// set the baseWaypoints

		towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower()
    {
		var oldTower = towerQueue.Dequeue();

		// set the placeable flags

		// set the baseWaypoints

		towerQueue.Enqueue(oldTower);
        
    }
}
