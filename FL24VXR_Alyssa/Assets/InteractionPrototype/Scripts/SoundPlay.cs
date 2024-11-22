using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip soundClip; // The sound to play

    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip); // Play the sound once
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned.");
        }
    }
}