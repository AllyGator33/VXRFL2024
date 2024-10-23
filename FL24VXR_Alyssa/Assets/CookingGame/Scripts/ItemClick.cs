using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    public GameObject[] prefabs; // Array to hold your prefabs
    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;

                // Retrieve the prefab instance ID
                int prefabId = clickedObject.GetInstanceID();
                Debug.Log("Clicked Object: " + clickedObject.name + ", Instance ID: " + prefabId);

                // Optionally, retrieve the prefab from the array
                GameObject prefab = GetPrefabByName(clickedObject.name);
                if (prefab != null)
                {
                    Debug.Log("Prefab ID: " + prefab.GetInstanceID());
                }
                
            }
        }
    }

    GameObject GetPrefabByName(string name)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab.name == name)
            {
                return prefab;
            }
        }
        return null; // Return null if not found
    }

}