using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1f;


    void Start()
    {
        StartCoroutine(PrintWaypointName());
        InvokeRepeating("PrintWaypointName", 0, 1f);
    }

    IEnumerator PrintWaypointName()
    {
        foreach(WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
