using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour 
{
	[SerializeField] Tower towerPrefab;
	[SerializeField] int towerLimit = 3;
    [SerializeField] GameObject towerParent;

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
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform; // organizes towers under a parent gameobject upon instantiation 
        baseWaypoint.isPlaceable = false;

		newTower.baseWaypoint = baseWaypoint;

		towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
		var oldTower = towerQueue.Dequeue();

		oldTower.baseWaypoint.isPlaceable = true; // free-up the block
		newBaseWaypoint.isPlaceable = false;
		
		oldTower.baseWaypoint = newBaseWaypoint;

		oldTower.transform.position = newBaseWaypoint.transform.position; // moves the tower

		towerQueue.Enqueue(oldTower);
        
    }
}
