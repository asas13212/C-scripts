using UnityEngine;

/// <summary>
/// Rotates a GameObject continuously around a specified axis.
/// Attach this script to any GameObject that should spin.
/// </summary>
public class ObjectRotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private Space rotationSpace = Space.Self;
    [SerializeField] private bool rotateOnStart = true;

    private bool isRotating;

    private void Start()
    {
        isRotating = rotateOnStart;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, rotationSpace);
        }
    }

    /// <summary>Starts the rotation.</summary>
    public void StartRotation() => isRotating = true;

    /// <summary>Stops the rotation.</summary>
    public void StopRotation() => isRotating = false;

    /// <summary>Toggles the rotation on/off.</summary>
    public void ToggleRotation() => isRotating = !isRotating;
}
