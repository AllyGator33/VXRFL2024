using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextMeshProUGUI theText;
    public GameObject textBox; // The dialogue text box
    public GameObject exclamationMark; // The initial indicator image
    public Transform player; // Reference to the player's Transform
    public bool onlyHorizontal = true; // Restrict rotation to Y-axis (optional)
    public TextAsset BugzyText;
    public string[] textlines;
    public int currentLine;
    public int endALine;

    public AudioClip[] dialogueSounds; // Array of audio clips
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        if (BugzyText != null)
        {
            textlines = BugzyText.text.Split('\n');
        }

        if (endALine == 0)
        {
            endALine = textlines.Length - 1;
        }

        // Ensure the dialogue box is initially hidden
        textBox.SetActive(false);

        // Get or add an AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (textBox.activeSelf)
        {
            theText.text = textlines[currentLine];

            if (player == null)
            {
                Debug.LogWarning("Player Transform is not assigned!");
                return;
            }
        }
    }

    public void NextLine()
    {
        currentLine += 1;

        if (currentLine > endALine)
        {
            textBox.SetActive(false);
        }
        else
        {
            PlayDialogueSound(currentLine);
        }
    }

    // Play the corresponding sound for the current line
    private void PlayDialogueSound(int lineIndex)
    {
        if (dialogueSounds != null && lineIndex < dialogueSounds.Length)
        {
            if (audioSource != null && dialogueSounds[lineIndex] != null)
            {
                audioSource.clip = dialogueSounds[lineIndex];
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for line " + lineIndex);
        }
    }

    // Method to handle clicking the exclamation mark
    public void StartDialogue()
    {
        Debug.Log("StartDialogue triggered");
        exclamationMark.SetActive(false); // Hide the exclamation mark
        textBox.SetActive(true); // Show the dialogue box
        PlayDialogueSound(currentLine); // Play the sound for the first line
    }
}