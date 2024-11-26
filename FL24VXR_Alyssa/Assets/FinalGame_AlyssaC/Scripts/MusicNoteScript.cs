using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MusicNote : MonoBehaviour
{
    public Transform collectPoint; // The point where the item will be placed
    public float pullSpeed = 5f; // Speed at which the object moves to the collection point
    public GameObject[] allowedObjects; // Array of allowed objects

    private GameObject collectedObject; // Tracks the object currently held by this collector
    private bool isCollecting = false; // Ensures only one object is being collected at a time

    private void OnTriggerEnter(Collider other)
    {
        // Ignore if already collecting or the collector has an object
        if (isCollecting || collectedObject != null)
            return;

        // Check if the object is in the list of allowed objects
        if (!IsAllowedObject(other.gameObject))
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

    private bool IsAllowedObject(GameObject obj)
    {
        // Check if the object is one of the allowed objects
        foreach (GameObject allowed in allowedObjects)
        {
            if (obj == allowed)
                return true;
        }
        return false;
    }

    private System.Collections.IEnumerator SuckInObject(GameObject obj)
    {
        // If already collecting, do nothing
        if (isCollecting)
            yield break;

        isCollecting = true;

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

        // Disable collisions to avoid interference
        Collider objCollider = obj.GetComponent<Collider>();
        if (objCollider != null)
        {
            objCollider.enabled = false;
        }

        // Gradually move the object to the collection point
        while (Vector3.Distance(obj.transform.position, collectPoint.position) > 0.01f)
        {
            obj.transform.position = Vector3.MoveTowards(
                obj.transform.position,
                collectPoint.position,
                pullSpeed * Time.deltaTime
            );
            yield return null;
        }

        // Snap the object to the collection point
        obj.transform.position = collectPoint.position;

        // Re-parent the object to the collector and mark it as collected
        obj.transform.SetParent(collectPoint);
        collectedObject = obj; // Store the collected object

        // Re-enable the collider to interact with the environment
        if (objCollider != null)
        {
            objCollider.enabled = true;
        }

        isCollecting = false;
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