using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Exclusive : MonoBehaviour
{
    public Transform collectPoint; // The point where the item will be placed
    public float pullSpeed = 5f; // Speed at which the object moves to the collection point
    public GameObject allowedObject; // The specific object this collector accepts

    private GameObject collectedObject; // Tracks the object currently held by this collector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collector already holds an object
        if (collectedObject != null)
            return;

        // Check if the object is the allowed object
        if (other.gameObject != allowedObject)
        {
            Debug.Log($"{other.gameObject.name} is not allowed in this collector.");
            return;
        }

        // Check if the object is being held by the player
        XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.isSelected)
        {
            // Stop the player from holding the object
            grabInteractable.interactionManager.CancelInteractableSelection(grabInteractable);

            // Start sucking the object in
            StartCoroutine(SuckInObject(other.gameObject));
        }
    }

    private System.Collections.IEnumerator SuckInObject(GameObject obj)
    {
        // If this collector already has an object, do nothing
        if (collectedObject != null)
            yield break;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        XRGrabInteractable grabInteractable = obj.GetComponent<XRGrabInteractable>();

        // Disable physics for smoother movement
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Disable the XRGrabInteractable component to make it non-grabbable
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }

        // Gradually move the object to the collection point
        while (Vector3.Distance(obj.transform.position, collectPoint.position) > 0.01f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, collectPoint.position, pullSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap the object to the collection point
        obj.transform.position = collectPoint.position;

        // Re-parent the object to the collector and mark it as collected
        obj.transform.SetParent(collectPoint);
        collectedObject = obj; // Store the collected object
    }

    public void ReleaseObject()
    {
        // If there is a collected object, release it
        if (collectedObject != null)
        {
            // Re-enable physics on the object
            Rigidbody rb = collectedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            // Re-enable the XRGrabInteractable component to make it grabbable again
            XRGrabInteractable grabInteractable = collectedObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = true;
            }

            // Unparent the object
            collectedObject.transform.SetParent(null);
            collectedObject = null; // Clear the reference
        }
    }
}