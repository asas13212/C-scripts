using UnityEngine;

/// <summary>
/// Exhibition / showcase script that slowly rotates a display object
/// and bobs it up and down for visual presentation.
/// Attach this script to any GameObject you want to showcase.
/// </summary>
public class Exhibition : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    [Header("Bob Settings")]
    [SerializeField] private bool enableBob = true;
    [SerializeField] private float bobHeight = 0.3f;
    [SerializeField] private float bobSpeed = 1.5f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Continuous rotation
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, Space.Self);

        // Bobbing up and down (only the Y axis is modified so X/Z remain unaffected)
        if (enableBob)
        {
            float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            Vector3 pos = transform.position;
            pos.y = startPosition.y + yOffset;
            transform.position = pos;
        }
    }
}
