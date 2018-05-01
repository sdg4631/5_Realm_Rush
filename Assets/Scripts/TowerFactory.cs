using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour 
{
	[SerializeField] Tower towerPrefab;
	[SerializeField] int towerLimit = 3;
	int numberOfTowers = 0;

	public void AddTower(Waypoint baseWaypoint)
	{
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
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numberOfTowers++;
    }

    private static void MoveExistingTower()
    {
        print("Tower Limit Reached!");
    }
}
