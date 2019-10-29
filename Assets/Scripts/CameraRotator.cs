using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple rotator controller for orbit camera rotation.
/// </summary>
public class CameraRotator : MonoBehaviour
{
    [SerializeField]
    private Transform center;
    [SerializeField]
    private float rotationSpeed;
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

    private void Rotate()
    {
        float speed = rotationSpeed * Input.GetAxis("Mouse X");
        this.transform.RotateAround(center.position, Vector3.up, speed);
    }
}
