using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{

    public GameObject[] prefabs; // Assign your prefabs in the Inspector                     
    public string RecipeName; //creates a public variable for the recipes name
    public int Recipeid; //creates a public variable for the recipes id
    public int numberOfPrefabs = 1; //this ensures that only one prefabs shows up in each RecLoc or PanLoc locations, can be changed from inspector
    public List<Ingredients> ingredients = new List<Ingredients>();//creates the ingredients list
    
    bool isRecipeActive = false;  //setting up a bool to use later to check recipe status when generating new recipe

    //public static bool earningsIncrease = true;
    void Start()
    {
        ingredients.Add(new Ingredients("Cube Red", 0, Resources.Load("Ingredients/CubeRed") as GameObject, 3)); //adds prefab to a list of ingredients, gives it id and dollar value
        ingredients.Add(new Ingredients("Sphere Blue", 1, Resources.Load("Ingredients/SphereBlue") as GameObject, 4)); //adds prefab to a list of ingredients, gives it id and dollar value
        ingredients.Add(new Ingredients("Sphere Orange", 2, Resources.Load("Ingredients/SphereOrange") as GameObject, 5)); //adds prefab to a list of ingredients, gives it id and dollar value
        ingredients.Add(new Ingredients("Green Cube", 3, Resources.Load("Ingredients/GreenCube") as GameObject, 6)); //adds prefab to a list of ingredients, gives it id and dollar value
        ingredients.Add(new Ingredients("Cylinder Pink", 4, Resources.Load("Ingredients/CylinderPink") as GameObject, 7)); //adds prefab to a list of ingredients, gives it id and dollar value

        SpawnRecipe(); //calls on spawnRecipe method to immediately spawn a random selection of ingredient when the game starts

    }

    public void SpawnRecipe()  //When called, spawns a random selection of ingredients in the recipe location empty game objects
    {

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)]; //sorts through all 5 prefabs and randomly picks 3 since I've assigned this script to the three RecLoc locations

            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);//creates a new instance for gameobjects to instantiate into
            instance.name = "RecipeItems" + name; //naming instance to make it easier to call on the RecLoc locations later

            // Disables the collider to make it unclickable
            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the collider
            }

        }
     
    }

    private void Update()
    {
        //utilizing the instance name I set up earlier to combine it with the RecLoc locations, also using the bool to check if the recipe is active
        if (!isRecipeActive && (GameObject.Find("RecipeItemsRecLoc2") == null || GameObject.Find("RecipeItemsRecLoc3") == null || GameObject.Find("RecipeItemsRecLoc1") == null))
        {
            Debug.Log("New Recipe Has Been Generated"); //setting up a debug to test if the code is working
            SpawnRecipe();   //calling on the spawnRecipe method

        }

    }
    private void OnMouseDown()
    {
        if (!Timer.isTimerActive) //using a bool to check when timer reaches zero 
        {
            Debug.Log("Cannot click, timer has ended!"); //setting up a debug to test if the code is working
            return; // Exit if the timer is not active
        }

        PanClick(); //callling on the pan click method to only destroy and respawn recipes when clicked on the pan 
   
    }

    public void PanClick()
    {

        Destroy(GameObject.Find("Pan Item 1"));//Finds instantiated pan object 1 and destroys it
        Destroy(GameObject.Find("Pan Item 2"));//Finds instantiated pan object 2 and destroys it
        Destroy(GameObject.Find("Pan Item 3"));//Finds instantiated pan object 3 and destroys it

        GameObject parent1 = GameObject.Find("RecLoc1");  // Find the parent object

        if (parent1 != null)//if parent is not null
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent1.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }

        // Find the parent object
        GameObject parent2 = GameObject.Find("RecLoc2");  // Find the parent object

        if (parent2 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent2.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }

        // Find the parent object
        GameObject parent3 = GameObject.Find("RecLoc3");  // Find the parent object

        if (parent3 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent3.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }

    }

  }

