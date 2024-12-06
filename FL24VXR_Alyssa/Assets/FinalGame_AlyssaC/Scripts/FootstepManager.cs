using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioSource footstepSource; // AudioSource for footstep sounds
    public AudioClip[] footstepClips; // Array of footstep audio clips
    public float stepInterval = 0.5f; // Time interval between footsteps
    public float movementThreshold = 0.1f; // Minimum movement speed to trigger footsteps

    private float stepTimer = 0f; // Timer to track time between steps
    private CharacterController characterController; // Reference to XR Rig's CharacterController
    private Vector3 previousPosition; // To calculate position-based movement

    private void Start()
    {
        // Ensure the AudioSource is assigned
        if (footstepSource == null)
        {
            footstepSource = GetComponent<AudioSource>();
            if (footstepSource == null)
            {
                Debug.LogError("No AudioSource found on the GameObject.");
            }
        }

        // Try to get the CharacterController
        characterController = GetComponent<CharacterController>();

        // Initialize previous position for position-based movement detection
        previousPosition = transform.position;
    }

    private void Update()
    {
        float speed = 0f;

        // Calculate movement speed using CharacterController or position changes
        if (characterController != null)
        {
            speed = characterController.velocity.magnitude;
        }
        else
        {
            Vector3 movement = transform.position - previousPosition;
            speed = new Vector3(movement.x, 0, movement.z).magnitude / Time.deltaTime;
            previousPosition = transform.position;
        }

        // Check if player is moving above the threshold
        if (speed > movementThreshold)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f; // Reset timer after playing a footstep
            }
        }
        else
        {
            // Reset the timer if player stops moving
            stepTimer = 0f;
        }
    }

    private void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            // Choose a random clip from the array
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            footstepSource.PlayOneShot(clip);
        }
    }
}
