using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Custom/Settings", order = 0)]
public class Settings : ScriptableObject
{
    [SerializeField]
    public Color32 paintColor;

    [Header("Camera")]
    [SerializeField]
    public float rotationSpeed;
}
