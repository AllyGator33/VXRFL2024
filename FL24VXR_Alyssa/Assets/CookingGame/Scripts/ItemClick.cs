using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;




public class ItemClick : MonoBehaviour
{
    //We start of by decalring a class variable of the type GameObject. This can be public if we  want to asing it from the editor.
    public GameObject CubeRed;
    public GameObject CylinderPink;
    public GameObject PanLoc1;
    public GameObject PanLoc2;
    public int clickCount = 0;
    private const int maxClicks = 3;

    // Use this for initialization
    void Start()
    {


        GameObject CubeRed = Resources.Load<GameObject>("Prefabs/CubeRed");
        if (CubeRed == null)

        {
            Debug.LogError("Prefab not found at specified path.");
        }

        //Now we will explore severel ways of how to asing our object from code.
        CubeRed = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        CubeRed = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
        //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.

        GameObject CylinderPink = Resources.Load<GameObject>("Prefabs/CylinderPink");
        if (CylinderPink == null)

        {
            Debug.LogError("Prefab not found at specified path.");
        }



        //Now we will explore severel ways of how to asing our object from code.
        CylinderPink = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        CylinderPink = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
        //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.

        {
            GameObject PanLoc1 = Resources.Load<GameObject>("Resources/Parents/PanLoc1");

            PanLoc1 = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
            PanLoc1 = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
                                                                                     //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.
        }


        {
            GameObject PanLoc2 = Resources.Load<GameObject>("Resources/Parents/PanLoc2");

            PanLoc2 = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
            PanLoc2 = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
                                                                                     //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.
        }
    }


    // Update is called once per frame
    void Update()
    {
        //GameObject tempObj = Instantiate(Cube1);   clones cube

        if (Input.GetMouseButtonDown(0))

        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is this GameObject
                if (hit.transform.gameObject == CubeRed)
                {
                    // Perform the action you want when the object is clicked
                    Debug.Log(gameObject.name + " was clicked!");

                }
            }
            // Now that we have a reference we can do what ever we want with the object. For example :
            CubeRed.transform.position = PanLoc1.transform.position;

        }

        {
         
        }
        if (Input.GetMouseButtonDown(0))

        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is this GameObject
                if (hit.transform.gameObject == CylinderPink)
                {
                    // Perform the action you want when the object is clicked
                    Debug.Log(gameObject.name + " was clicked!");

                }
            }
            // Now that we have a reference we can do what ever we want with the object. For example :
            CylinderPink.transform.position = PanLoc2.transform.position;
            //moves object to empty game object location
        }
    }

    public void RegisterClick()
    {
        if (clickCount < maxClicks)
        {
            // Increment click count
            clickCount++;
            Debug.Log("Click count: " + clickCount);

            // Additional logic when the click count reaches the max
            if (clickCount >= maxClicks)
            {
                Debug.Log("Maximum click count reached!");
                // Here you can call a method to handle the max click scenario
                HandleMaxClicks();
            }
        }
    }

    // Example method to handle what happens when max clicks are reached
    private void HandleMaxClicks()
    {
        if (clickCount >= maxClicks)
        {
            // Disable further clicks

        }
        // You can implement any logic here, like disabling objects
        Debug.Log("No more clicks allowed.");
    }
}
