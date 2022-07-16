using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetWaypointManager : MonoBehaviour
{
    public List<Transform> waypoints { get; private set; }

    void Start()
    {
        waypoints = GetComponentsInChildren<Transform>().ToList();
        waypoints.Remove(waypoints[0]); //Removes parent object
    }


}
