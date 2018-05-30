using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Ignoring overlapping waypoint: " + waypoint.GetGridPos());
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                print(waypoint);
            }
        }
        print(grid.Count);
    }
}
