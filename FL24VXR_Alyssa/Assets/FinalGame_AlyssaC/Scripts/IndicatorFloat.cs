using UnityEngine;

public class FloatingExclamationMark : MonoBehaviour
{
    private Vector3 initialPosition; // Store the starting position
    public float floatAmplitude = 0.2f; // How high/low it floats
    public float floatSpeed = 1.5f; // Speed of the floating motion

    void Start()
    {
        // Store the initial position of the GameObject
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}