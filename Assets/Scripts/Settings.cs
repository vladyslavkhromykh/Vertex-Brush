using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Custom/Settings", order = 0)]
internal class Settings : ScriptableObject
{
    [SerializeField]
    internal Color32 paintColor;

    [Header("Camera")]
    [SerializeField]
    internal float rotationSpeed;
}
