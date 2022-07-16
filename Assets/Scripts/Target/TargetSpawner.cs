using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private int targetCap;
    [field: SerializeField] public TargetWaypointManager waypointManager { get; private set; }
    private GameObject targetClone;

    void Start()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        targetClone = Instantiate(target, this.transform.position, this.transform.rotation);
        targetClone.transform.parent = this.transform;
    }

    public void DestroyTarget()
    {
        Destroy(targetClone, 2f);
    }
}
