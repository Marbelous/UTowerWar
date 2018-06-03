using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();  // todo: make private

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
            ColorPath();
        }
        return path;
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                //Debug.LogWarning("Ignoring overlapping waypoint: " + waypoint.GetGridPos());
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            StopOnGoal();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoord = searchCenter.GetGridPos() + direction;

            if (grid.ContainsKey(neighborCoord))
            {
                QueueNewNeighbors(neighborCoord);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoord)
    {
        Waypoint neighbor = grid[neighborCoord];

        if (neighbor.isExplored || queue.Contains(neighbor)) { return; }

        queue.Enqueue(neighbor);
        neighbor.exploredFrom = searchCenter;
    }

    private void StopOnGoal()
    {
        if (searchCenter == endWaypoint)
        {
            print("Goal Found!");
            isRunning = false;
        }
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void ColorPath()
    {
        var pathToColor = path.GetRange(0, path.Count);
        pathToColor.Remove(startWaypoint);
        pathToColor.Remove(endWaypoint);
        foreach (var pathWayPoint in pathToColor)
        {
            pathWayPoint.SetTopColor(Color.yellow);
        }
    }
}
