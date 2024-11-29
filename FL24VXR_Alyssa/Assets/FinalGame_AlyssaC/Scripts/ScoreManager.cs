using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit; // For XR interactions

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score UI text
    public int currentScore = 0; // The player's current score
    private int maxScore = 8; // Maximum score (total objects to collect)

    public GameObject buttonObject; // The GameObject with the Box Collider
    public AudioClip clickSound; // The sound to play when the button is clicked
    private AudioSource audioSource; // AudioSource to play the sound

    private bool isColliderActive = false; // Track if the collider is active

    // Method to increment the score
    public void AddScore()
    {
        if (currentScore < maxScore)
        {
            currentScore++;
            UpdateScoreUI();
        }
    }

    // Update the score UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Notes Collected: " + currentScore + " / " + maxScore;
    }

    private void Start()
    {
        UpdateScoreUI(); // Initialize the UI at the start of the game
        audioSource = gameObject.GetComponent<AudioSource>(); // Get the audio source

        if (buttonObject != null)
        {
            // Initially disable the collider on the button
            buttonObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void Update()
    {
        // Check if score has reached maxScore and enable the collider if it has
        if (currentScore == maxScore && !isColliderActive)
        {
            ButtonActivate();
        }
    }

    // Method to activate the button collider when max score is reached
    private void ButtonActivate()
    {
        if (buttonObject != null)
        {

            //buttonObject.SetActive(true);
            // Enable the collider on the button
            Collider buttonCollider = buttonObject.GetComponent<Collider>();
            if (buttonCollider != null)
            {
                buttonCollider.enabled = true;
                isColliderActive = true;
            }
        }
    }

    // Method to handle button press interaction (e.g., VR controller click)
    public void OnButtonPressed()
    {
        if (isColliderActive && buttonObject != null)
        {
            // Play sound when button is pressed
            if (clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }

            //// Optionally, disable the collider after it has been clicked
            //buttonObject.GetComponent<Collider>().enabled = false;
            //isColliderActive = false;
        }
    }
}