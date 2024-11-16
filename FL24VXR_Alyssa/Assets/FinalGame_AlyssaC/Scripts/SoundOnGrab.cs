using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//if want to make it so that sound plays on every grab, take out the bool!
public class PlaySoundOnceOnGrab : MonoBehaviour
{
    public AudioClip grabSound; // The sound to play
    private AudioSource audioSource;
    private bool hasPlayedSound = false; // Tracks if the sound has been played

    private void Awake()
    {
        // Ensure the object has an XRGrabInteractable component
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component is missing on this object!");
            return;
        }

        // Add an AudioSource component if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Subscribe to the select entered event (grab event)
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Play the sound only if it hasn't been played yet
        if (!hasPlayedSound && grabSound != null)
        {
            audioSource.PlayOneShot(grabSound);
            hasPlayedSound = true; // Mark that the sound has been played
        }
    }

    private void OnDestroy()
    {
        // Clean up to avoid memory leaks
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}