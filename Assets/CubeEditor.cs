﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
 {
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
        (
            waypoint.GetGridPos().x * gridSize, 
            0f, 
            waypoint.GetGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {      
        string labelText = 
            waypoint.GetGridPos().x + 
            "," + 
            waypoint.GetGridPos().y;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;
        gameObject.name = "Waypoint " + labelText;
    }
}
