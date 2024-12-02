using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlowOnPlacement : MonoBehaviour
{
    public GameObject targetParent; // The parent object
    public Material glowMaterial; // The glow material
    private Material originalMaterial; // To store the original material
    private Renderer objectRenderer; // Renderer of the GameObject

    void Start()
    {
        // Get the Renderer of the GameObject
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            // Store the original material
            originalMaterial = objectRenderer.material;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the GameObject and is placed inside the targetParent
        if (other.gameObject == targetParent)
        {
            // Change the material to the glow material
            if (objectRenderer != null && glowMaterial != null)
            {
                objectRenderer.material = glowMaterial;
            }
        }
    }

    //void Update()
    //{
    //    float glowIntensity = Mathf.PingPong(Time.time, 1.5f) + 1f; // Dynamic intensity
    //    if (objectRenderer != null && glowMaterial != null)
    //    {
    //        glowMaterial.SetColor("_EmissionColor", Color.yellow * glowIntensity);
    //    }
    //}

    void OnTriggerExit(Collider other)
    {
        // Restore the original material when it exits the parent
        if (other.gameObject == targetParent)
        {
            if (objectRenderer != null && originalMaterial != null)
            {
                objectRenderer.material = originalMaterial;
            }
        }
    }
}