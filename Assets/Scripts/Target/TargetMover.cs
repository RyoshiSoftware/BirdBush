using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TargetMover : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private AudioSource poofAudioSource;
    [SerializeField] private VisualEffect smokePoof;
    [SerializeField] private GameObject mesh;

    private TargetSpawner targetSpawner;
    private TargetWaypointManager waypointManager;
    private int waypointCounter = 0;
    private Vector3 currentWaypointPosition;
    private float flightSpeed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        flightSpeed = movementSpeed * Time.deltaTime;
        targetSpawner = GetComponentInParent<TargetSpawner>();
        waypointManager = targetSpawner.waypointManager;
        GetPathToPoint();
        animator.SetFloat("Blend", 1f);
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
            AudioSource poofSource = Instantiate(poofAudioSource);
            Destroy(poofSource, 3f);

            mesh.SetActive(false);
            
            smokePoof.Play();

            Destroy(this.gameObject, 2f);
            targetSpawner.targetCount--;
        }
    }
}
