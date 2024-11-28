using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FloatAndStopOnGrab : MonoBehaviour
{
    public float floatSpeed = 1f; // Speed of the floating motion
    public float floatAmplitude = 0.5f; // Height of the floating motion
    private Vector3 startPosition; // Starting position of the object
    private bool isGrabbed = false; // Tracks if the object is grabbed

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add event listeners for grabbing and releasing
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    private void Update()
    {
        // If the object is not grabbed, apply the floating effect
        if (!isGrabbed)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Reset the floating effect after release
        isGrabbed = false;
        startPosition = transform.position; // Update the start position
    }

}