using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public Transform correctParent; // The parent location for this object
    private bool isPlaced = false; // Ensure scoring happens only once
    public ScoreManager scoreManager; // Reference to the ScoreManager

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with its correct parent
        if (other.transform == correctParent && !isPlaced)
        {
            isPlaced = true; // Mark the object as placed to prevent double-scoring

            // Snap the object to the correct parent's position
            transform.position = correctParent.position;
            transform.rotation = correctParent.rotation;

            // Notify the ScoreManager
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }

            // Optional: Disable further interaction with the object
            GetComponent<Collider>().enabled = false;
        }
    }
}