using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RanchText : MonoBehaviour
{
    public TextMeshProUGUI theRanchText;
    public GameObject RanchTextBox;
    public Transform player; // Reference to the player's Transform
    public bool onlyHorizontal = true; // Restrict rotation to Y-axis (optional)
    public TextAsset ranchText;
    public string[] RanchLines;
    public int currentRanchLine;
    public int RanchEndLine;

    public AudioClip[] dialogueSounds; // Array of audio clips
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        if (ranchText != null)
        {
            RanchLines = ranchText.text.Split('\n');
        }

        if (RanchEndLine == 0)
        {
            RanchEndLine = RanchLines.Length - 1;
        }

        // Ensure the dialogue box is initially hidden
        //RanchTextBox.SetActive(false);

        // Get or add an AudioSource component
        //audioSource = gameObject.GetComponent<AudioSource>();
        //if (audioSource == null)
        //{
        //    audioSource = gameObject.AddComponent<AudioSource>();
        //}
    }

    private void Update()
    {
        if (RanchTextBox.activeSelf)
        {
            theRanchText.text = RanchLines[currentRanchLine];

            if (player == null)
            {
                Debug.LogWarning("Player Transform is not assigned!");
                return;
            }
        }
    }

    public void NextLine()
    {
        currentRanchLine += 1;

        if (currentRanchLine > RanchEndLine)
        {
            RanchTextBox.SetActive(false);
        }
        //else
        //{
        //    PlayDialogueSound(currentRanchLine);
        //}
    }

    // Play the corresponding sound for the current line
    //private void PlayDialogueSound(int lineIndex)
    //{
    //    if (dialogueSounds != null && lineIndex < dialogueSounds.Length)
    //    {
    //        if (audioSource != null && dialogueSounds[lineIndex] != null)
    //        {
    //            audioSource.clip = dialogueSounds[lineIndex];
    //            audioSource.Play();
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No audio clip assigned for line " + lineIndex);
    //    }
    //}

    // Method to handle clicking the exclamation mark
    public void StartDialogue()
    {
        Debug.Log("StartDialogue triggered");
        //exclamationMark.SetActive(false); // Hide the exclamation mark
        RanchTextBox.SetActive(true); // Show the dialogue box
        //PlayDialogueSound(currentLine); // Play the sound for the first line
    }
}