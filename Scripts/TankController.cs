using UnityEngine;

/// <summary>
/// Tank-style movement controller.
/// The object rotates left/right with A/D and moves forward/backward with W/S.
/// Attach this script to a tank or any GameObject that uses tank-style controls.
/// </summary>
public class TankController : MonoBehaviour
{
    [Header("Tank Settings")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 120f;

    private void Update()
    {
        HandleTankMovement();
    }

    private void HandleTankMovement()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Rotate the tank
        if (turnInput != 0f)
        {
            float turn = turnInput * turnSpeed * Time.deltaTime;
            transform.Rotate(0f, turn, 0f);
        }

        // Move the tank forward/backward
        if (moveInput != 0f)
        {
            Vector3 move = transform.forward * moveInput * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);
        }
    }
}
