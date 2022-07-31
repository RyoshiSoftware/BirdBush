using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private int targetCap = 3;
    [SerializeField] private float timeRemaining = 3;
    [field: SerializeField] public TargetWaypointManager waypointManager { get; private set; }
    private GameObject targetClone;
    private int targetCount = 0;

    void Start()
    {
        timeRemaining = UnityEngine.Random.Range(3f, 10f);
    }

    private void Update() 
    {
        if (targetCount < targetCap)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                SpawnTarget();
                timeRemaining = UnityEngine.Random.Range(3f, 10f);;
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        DestroyTarget();
    }

    private void SpawnTarget()
    {
        targetCount ++;
        targetClone = Instantiate(target, this.transform.position, this.transform.rotation);
        targetClone.transform.parent = this.transform;
    }

    public void DestroyTarget()
    {
        Destroy(targetClone, 2f);
    }
}
