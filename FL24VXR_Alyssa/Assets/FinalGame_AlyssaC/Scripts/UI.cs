using UnityEngine;

public class UILockOnPlayer : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera (XR Rig)
    public Vector3 offset = new Vector3(0, 2, 2); // Position offset relative to the camera

    void Update()
    {
        if (playerCamera == null)
        {
            Debug.LogWarning("Player camera is not assigned!");
            return;
        }

        // Position the UI text at a fixed offset relative to the camera
        transform.position = playerCamera.position + playerCamera.forward * offset.z
                             + playerCamera.up * offset.y
                             + playerCamera.right * offset.x;

        // Make the UI text face the player
        transform.LookAt(playerCamera);
        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.position);
    }
}