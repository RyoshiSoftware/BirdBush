using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetMover : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private TargetSpawner targetSpawner;
    private TargetWaypointManager waypointManager;
    private int waypointCounter = 0;
    private Vector3 currentWaypointPosition;

    void Start()
    {
        targetSpawner = GetComponentInParent<TargetSpawner>();
        waypointManager = targetSpawner.waypointManager;
        GetPathToPoint();
    }

    private void GetPathToPoint()
    {
        currentWaypointPosition = waypointManager.waypoints[waypointCounter].position;
        waypointCounter ++;
        if (waypointCounter >= waypointManager.waypoints.Count) { waypointCounter = 0; }
        MoveToCurrentWaypoint();
    }

    private void MoveToCurrentWaypoint()
    {
        this.transform.DOMove(currentWaypointPosition, movementSpeed, false)
            .OnComplete(GetPathToPoint);
    }
}
