using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class BoxEditor : MonoBehaviour
{
    Vector3 snapPos = new Vector3();
    TextMesh posText;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh posText = GetComponentInChildren<TextMesh>();
        string BoxPosText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        posText.text = BoxPosText;
        gameObject.name = "Box: " + BoxPosText;
    }
}
