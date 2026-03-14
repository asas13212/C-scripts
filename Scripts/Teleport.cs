using UnityEngine;

/// <summary>
/// Teleports a GameObject to a target position when a specified key is pressed
/// or when TeleportTo() is called from another script.
/// Attach this script to the object you want to teleport.
/// </summary>
public class Teleport : MonoBehaviour
{
    [Header("Teleport Settings")]
    [SerializeField] private Transform targetPosition;
    [SerializeField] private KeyCode teleportKey = KeyCode.T;
    [SerializeField] private bool useKeyboardTrigger = true;

    [Header("Effects")]
    [SerializeField] private GameObject teleportEffect;

    private void Update()
    {
        if (useKeyboardTrigger && Input.GetKeyDown(teleportKey))
        {
            TeleportTo(targetPosition);
        }
    }

    /// <summary>
    /// Teleports this object to the given Transform's position.
    /// </summary>
    /// <param name="destination">The destination Transform to teleport to.</param>
    public void TeleportTo(Transform destination)
    {
        if (destination == null)
        {
            Debug.LogWarning("Teleport: No destination assigned.");
            return;
        }

        SpawnEffect(transform.position);
        transform.position = destination.position;
        SpawnEffect(transform.position);
    }

    /// <summary>
    /// Teleports this object to the given world position.
    /// </summary>
    /// <param name="position">The world-space position to teleport to.</param>
    public void TeleportTo(Vector3 position)
    {
        SpawnEffect(transform.position);
        transform.position = position;
        SpawnEffect(transform.position);
    }

    private void SpawnEffect(Vector3 position)
    {
        if (teleportEffect != null)
        {
            Instantiate(teleportEffect, position, Quaternion.identity);
        }
    }
}
