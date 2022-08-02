using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;

    private TargetSpawner targetSpawner;
    private TargetWaypointManager waypointManager;
    private int waypointCounter = 0;
    private Vector3 currentWaypointPosition;
    private float flightSpeed;

    void Start()
    {
        flightSpeed = movementSpeed * Time.deltaTime;
        targetSpawner = GetComponentInParent<TargetSpawner>();
        Debug.Log(targetSpawner);
        waypointManager = targetSpawner.waypointManager;
        GetPathToPoint();
    }

    private void Update() 
    {
        Transform target = waypointManager.waypoints[waypointCounter];
        transform.LookAt(target);
        if (Vector3.Distance(transform.position, currentWaypointPosition) < 0.5f) { GetPathToPoint(); }
        transform.position = Vector3.MoveTowards(transform.position, currentWaypointPosition, flightSpeed);

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
        float flightSpeed = movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(this.gameObject);
            targetSpawner.targetCount--;
        }
    }
}
