using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    //We start of by decalring a class variable of the type GameObject. This can be public if we  want to asing it from the editor.
    public List<GameObject> gameObjects; // Assign your GameObjects in the Inspector
    public Vector3 minPosition; // Minimum bounds for random position
    public Vector3 maxPosition; // Maximum bounds for random position
    public int maxClicks = 3;  // Maximum number of GameObjects that can be clicked
    public static int clickCount = 0; // Counter for the number of clicks
  //  private Renderer _renderer;
    private Vector3 ingSpawn = new Vector3(-1.28f,2.52f,-3.73f);


    //public bool CanClick { get; private set; } = true;

    // Use this for initialization
    private void Start()
    {
        gameObjects = new List<GameObject>();
        //   // _renderer = GetComponent<Renderer>();


        //    GameObject CubeRed = Resources.Load<GameObject>("Prefabs/CubeRed");
        //    if (CubeRed == null)

        //    {
        //        Debug.LogError("Prefab not found at specified path.");
        //    }

        //    //Now we will explore severel ways of how to asing our object from code.
        //    CubeRed = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        //    CubeRed = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
        //    //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.

        //    GameObject CylinderPink = Resources.Load<GameObject>("Prefabs/CylinderPink");
        //    if (CylinderPink == null)

        //    {
        //        Debug.LogError("Prefab not found at specified path.");
        //    }



        //    //Now we will explore severel ways of how to asing our object from code.
        //    CylinderPink = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        //    CylinderPink = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag
        //                                                                                  //By making the field public in the declaration we could also simply use drag and drop to asing the reference from the unity editor. There are plenty of tutorials online for this.

        //    GameObject SphereBlue = Resources.Load<GameObject>("Prefabs/SphereBlue");
        //    if (SphereBlue == null)

        //    {
        //        Debug.LogError("Prefab not found at specified path.");
        //    }

        //    SphereBlue = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        //    SphereBlue = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag

        //    GameObject SphereOrange = Resources.Load<GameObject>("Prefabs/SphereOrange");
        //    if (SphereOrange == null)

        //    {
        //        Debug.LogError("Prefab not found at specified path.");
        //    }

        //    SphereOrange = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        //    SphereOrange = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag

        //    GameObject GreenCube = Resources.Load<GameObject>("Prefabs/GreenCube");
        //    if (GreenCube == null)

        //    {
        //        Debug.LogError("Prefab not found at specified path.");
        //    }

        //    GreenCube = GameObject.Find("Name of the object in the scene");//This will search for the object by name;
        //    GreenCube = GameObject.FindGameObjectWithTag("The tag of the game object");//This will find a gameObject with the specified tag


    }


        // Update is called once per frame
         private void OnMouseDown()
        {
        if(clickCount == 3)
        {
            return; //keyword to exit function early
        }
        gameObjects.Add(gameObject);
        Instantiate(gameObject,new(-1.28f+clickCount, 2.52f, -3.73f), Quaternion.identity);
        clickCount++;
      

       }

    }

