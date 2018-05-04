using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting Patrol...");
        foreach (var waypoint in path)
        {
            print("Visiting: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol.");
    }
}
