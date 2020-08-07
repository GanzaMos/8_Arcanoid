using UnityEngine;

[ExecuteInEditMode]
public class DeveloperScriptForBlocks : MonoBehaviour

{ 
    
    void Awake()
    {
        SnapToGrid();
    }
    
    void Update()
    {
        SnapToGrid();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector2(
            0.5f + Mathf.RoundToInt(transform.position.x),
            0.5f + Mathf.RoundToInt(transform.position.y)
        );
    }
}
