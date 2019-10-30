using System;
using UnityEngine;

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

    private void OnPointerUpdatedPosition(RaycastHit hit)
    {
        visualizer.transform.position = hit.point;
        visualizer.transform.up = hit.normal;
    }
}
