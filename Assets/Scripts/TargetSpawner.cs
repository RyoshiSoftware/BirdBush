using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class TargetSpawner : MonoBehaviour
{

    [field: SerializeField] private GameObject target;
    private GameObject targetClone;

    void Start()
    {
        SpawnTarget();
        DestroyTarget();
    }

    private void DestroyTarget()
    {
        Destroy(targetClone, 2f);
    }

    private void SpawnTarget()
    {
        targetClone = Instantiate(target, this.transform.position, this.transform.rotation);
    }

    void Update()
    {
        
    }
}
