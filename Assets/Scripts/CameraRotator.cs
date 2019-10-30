using UnityEngine;

/// <summary>
/// Simple rotation controller for orbit camera rotation.
/// </summary>
public class CameraRotator : MonoBehaviour
{
    public Settings settings;
    [SerializeField]
    private Transform center;
    private Transform transform;

    private void Awake()
    {
        this.transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Rotate();
        }
    }

    /// <summary>
    /// Rotates camera with speed value around defined center.
    /// </summary>
    private void Rotate()
    {
        float speed = settings.rotationSpeed * Input.GetAxis("Mouse X");
        this.transform.RotateAround(center.position, Vector3.up, speed);
    }
}
