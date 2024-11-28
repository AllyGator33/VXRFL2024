using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TradeManager : MonoBehaviour
{
    public GameObject itemToPlace;        // The item required for the trade (e.g., ItemA)
    public Transform tradeZone;          // The target area to place the item
    public GameObject itemToUnlock;      // The item to unlock (e.g., ItemB)
    private XRGrabInteractable unlockableInteractable;

    private bool isItemPlaced = false;

    void Start()
    {
        // Ensure the unlockable item is initially locked
        unlockableInteractable = itemToUnlock.GetComponent<XRGrabInteractable>();
        if (unlockableInteractable != null)
        {
            unlockableInteractable.enabled = false; // Disable grabbing
            Debug.Log($"{itemToUnlock.name} is initially locked.");
        }
        else
        {
            Debug.LogError($"XRGrabInteractable component missing on {itemToUnlock.name}!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == itemToPlace && !isItemPlaced)
        {
            Debug.Log($"{itemToPlace.name} entered the trade zone.");
            PlaceItem(other.gameObject);
        }
    }

    private void PlaceItem(GameObject item)
    {
        isItemPlaced = true;

        // Snap item to the trade zone position
        item.transform.position = tradeZone.position;
        item.transform.rotation = tradeZone.rotation;
        item.transform.SetParent(tradeZone); // Ensure it stays in the trade zone

        // Unlock the item
        UnlockItem();
    }

    private void UnlockItem()
    {
        if (unlockableInteractable != null && isItemPlaced)
        {
            unlockableInteractable.enabled = true; // Enable grabbing
            Debug.Log($"{itemToUnlock.name} is now unlocked and grabbable!");
        }
        else if (!isItemPlaced)
        {
            Debug.LogWarning("UnlockItem was called, but the item was not placed.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == itemToPlace && isItemPlaced)
        {
            Debug.Log($"{itemToPlace.name} exited the trade zone.");
            RemoveItem();
        }
    }

    private void RemoveItem()
    {
        isItemPlaced = false;

        // Lock the item again
        LockItem();
    }

    private void LockItem()
    {
        if (unlockableInteractable != null)
        {
            unlockableInteractable.enabled = false; // Disable grabbing
            Debug.Log($"{itemToUnlock.name} is now locked.");
        }
    }
}