using UnityEngine;

public class ButtonActionWithSound : MonoBehaviour
{
    public AudioSource audioSource; // Reference to an AudioSource component
    public AudioClip clickSound;    // Reference to the sound to play

    public void DoSomething()
    {
        Debug.Log("Button clicked in VR!");

        // Play the click sound
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // Add other functionality here
    }
}