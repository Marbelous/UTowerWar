using UnityEngine;

public class Waypoint : MonoBehaviour
{

    const int gridSize = 10;

    Vector2 gridPos;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2 GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }
}
