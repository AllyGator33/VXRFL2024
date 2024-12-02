using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(XRGrabInteractable))]
public class PlaySoundOnGrab : MonoBehaviour
{
    public AudioClip grabSound; // The sound to play when grabbed
    private AudioSource audioSource; // Reference to the AudioSource component

    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Ensure the AudioSource is properly set up
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the XRGrabInteractable is set
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register the grab event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Play the grab sound
        if (grabSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(grabSound);
        }
    }

    private void OnDestroy()
    {
        // Unregister the grab event to avoid memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}
