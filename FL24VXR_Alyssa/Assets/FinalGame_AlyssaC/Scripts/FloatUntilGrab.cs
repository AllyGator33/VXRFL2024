using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.2f; // How high/low the object floats
    public float floatFrequency = 1f;  // How fast the object floats

    private Vector3 initialPosition;   // The starting position of the object
    private bool isFloating = true;    // Tracks whether the object should float

    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable

    void Start()
    {
        // Save the initial position
        initialPosition = transform.position;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register events for grab
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    void Update()
    {
        if (isFloating)
        {
            // Calculate the new floating position
            float newY = initialPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Stop the floating permanently when grabbed
        isFloating = false;

        // Optionally unregister the event after it triggers
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnDestroy()
    {
        // Clean up event listeners
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}
