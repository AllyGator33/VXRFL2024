using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    // Variables for customization
    public float amplitude = 0.5f; // The height of the float
    public float frequency = 1f;   // The speed of the float

    // Starting position
    private Vector3 startPos;

    void Start()
    {
        // Record the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Update the position of the GameObject
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
