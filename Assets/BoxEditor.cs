using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class BoxEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    Vector3 snapPos = new Vector3();

    void Update()
    {
        TextMesh posText = GetComponentInChildren<TextMesh>();

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        string BoxPosText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        posText.text = BoxPosText;
        gameObject.name = "Box: " + BoxPosText;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
