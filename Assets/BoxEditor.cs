using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class BoxEditor : MonoBehaviour
{
    //TextMesh posText;
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
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh posText = GetComponentInChildren<TextMesh>();
        string BoxPosText =
            waypoint.GetGridPos().x +
            "," +
            waypoint.GetGridPos().y;

        posText.text = BoxPosText;
        gameObject.name = "Box: " + BoxPosText;
    }
}
