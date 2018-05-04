using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class BoxEditor : MonoBehaviour
{
    const int gridSize = 10;
    Vector3 snapPos = new Vector3();

    TextMesh posText;

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        TextMesh posText = GetComponentInChildren<TextMesh>();
        string BoxPosText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        posText.text = BoxPosText;
        gameObject.name = "Box: " + BoxPosText;
    }

    private void SnapToGrid()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
