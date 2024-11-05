using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private Renderer objectRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();  

        if (objectRenderer = null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);    
        }

        else
        {
            Debug.Log("Not working");
        }
    }

   
}
