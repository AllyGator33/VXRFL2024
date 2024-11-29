using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score UI text
    public int currentScore = 0; // The player's current score
    private int maxScore = 8; // Maximum score (total objects to collect)

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
    }
}


//if current score = max score then activates script that allows button to be pressed