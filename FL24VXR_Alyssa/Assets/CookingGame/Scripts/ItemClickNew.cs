using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickNew : MonoBehaviour
{


    public GameObject[] gameObjects; // Assign your GameObjects in the Inspector
    public Vector3 minPosition; // Minimum bounds for random position
    public Vector3 maxPosition; // Maximum bounds for random position

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            MoveRandomObject();
        }

    }

    void MoveRandomObject()
    {
        // Check if there are GameObjects assigned
        if (gameObjects.Length > 0)
        {
            // Pick a random GameObject from the array
            int randomIndex = Random.Range(0, gameObjects.Length);
            GameObject selectedObject = gameObjects[randomIndex];

            // Generate a random position within specified bounds
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
            );

            // Move the selected GameObject to the random position
            selectedObject.transform.position = randomPosition;
        }
    }
}
