using UnityEngine;

/// <summary>
/// Controller that serves as a visualizer for painting brush.
/// </summary>
public class PainterVisualizer : MonoBehaviour
{
    [SerializeField]
    private GameObject visualizerPrefab;
    [SerializeField]
    private Painter painter;
    private Transform visualizer;
    
    private void Awake()
    {
        visualizer = Instantiate(visualizerPrefab).GetComponent<Transform>();
        painter.PointerUpdatedPosition += OnPointerUpdatedPosition;
    }

    /// <summary>
    /// PointerUpdatedPosition event subscriber that visualizes pointer position/orientation.
    /// </summary>
    /// <param name="hit"></param>
    private void OnPointerUpdatedPosition(RaycastHit hit)
    {
        visualizer.transform.position = hit.point;
        visualizer.transform.up = hit.normal;
    }
}
