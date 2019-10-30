using System;
using UnityEngine;

/// <summary>
/// Controller that serves as a tool for painting objects with Paintable layer.
/// </summary>
[RequireComponent(typeof(Camera))]
internal sealed class Painter : MonoBehaviour
{
    public event Action<RaycastHit> PointerUpdatedPosition; 
    public Settings settings;
    private Camera camera;
    private Color32[] colors;
    private int previousTriangleIndex = -1;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    
    private void Update()
    {
        RaycastHit hit;
        Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50.0f, 1 << 8))
        {
            Mesh mesh = hit.collider.GetComponent<MeshFilter>().mesh;
            if (colors == null)
            {
                InitializeColors(mesh);
            }

            int triangleIndex = hit.triangleIndex;
            if (triangleIndex != previousTriangleIndex)
            {
                previousTriangleIndex = triangleIndex;
                PointerUpdatedPosition?.Invoke(hit);
            }

            if (Input.GetMouseButton(0))
            {
                int[] triangles = mesh.triangles;
                colors[triangles[hit.triangleIndex * 3 + 0]] = settings.paintColor;
                colors[triangles[hit.triangleIndex * 3 + 1]] = settings.paintColor;
                colors[triangles[hit.triangleIndex * 3 + 2]] = settings.paintColor;
            
                mesh.colors32 = colors;
            }
        }
    }

    private void InitializeColors(Mesh mesh)
    {
        colors = new Color32[mesh.vertexCount];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }
    }
}
