using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.2f; // How high/low the object floats
    public float floatFrequency = 1f;  // How fast the object floats

    public AudioSource externalAudioSource; // Reference to the external audio source
    public float fadeDuration = 1f;         // Duration of the fade-out in seconds

    private Vector3 initialPosition;   // The starting position of the object
    private bool isFloating = true;    // Tracks whether the object should float

    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable

    void Start()
    {
        // Save the initial position
        initialPosition = transform.position;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register events for grab
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    void Update()
    {
        if (isFloating)
        {
            // Calculate the new floating position
            float newY = initialPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Stop the floating permanently when grabbed
        isFloating = false;

        // Fade out the external audio source
        if (externalAudioSource != null && externalAudioSource.isPlaying)
        {
            StartCoroutine(FadeOutAudio(externalAudioSource, fadeDuration));
        }

        // Optionally unregister the event after it triggers
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnDestroy()
    {
        // Clean up event listeners
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private System.Collections.IEnumerator FadeOutAudio(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        // Gradually reduce the volume
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        // Ensure the volume is set to 0 and stop the audio
        audioSource.volume = 0;
        audioSource.Stop();

        // Restore the original volume if needed for reuse
        audioSource.volume = startVolume;
    }
}
