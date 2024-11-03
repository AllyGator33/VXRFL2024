using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RecipeBook : MonoBehaviour
{

    public GameObject[] prefabs; // Assign your prefabs in the Inspector
                                 // public GameObject parentObject; // Reference to the empty GameObject
    public string RecipeName;
    public int Recipeid;
    public int numberOfPrefabs = 1;
    //syntax for list is <>, name of,   setting new values
    public List<Ingredients> ingredients = new List<Ingredients>();
    public List<int> usedIngredient = new List<int>();
   public List<Recipe> recipes = new List<Recipe>();
   //public RecipeManager recipeManager;
    bool isMatch = false;

    bool isRecipeActive = false;
    // List of all possible ingredients

    //public static bool earningsIncrease = true;
    void Start()
    {
        ingredients.Add(new Ingredients("Cube Red", 0, Resources.Load("Ingredients/CubeRed") as GameObject, 3));
        ingredients.Add(new Ingredients("Sphere Blue", 1, Resources.Load("Ingredients/SphereBlue") as GameObject, 4));
        ingredients.Add(new Ingredients("Sphere Orange", 2, Resources.Load("Ingredients/SphereOrange") as GameObject, 5));
        ingredients.Add(new Ingredients("Green Cube", 3, Resources.Load("Ingredients/GreenCube") as GameObject, 6));
        ingredients.Add(new Ingredients("Cylinder Pink", 4, Resources.Load("Ingredients/CylinderPink") as GameObject, 7));

        recipes.Add(new Recipe("Recipe 1", 0, RandomIngredientList()));




        // Create a new recipe with a random ingredient list


        //void Shuffle(List<int> templist)
        //{
        //    System.Random rng = new System.Random();
        //    int n = ingredients.Count;
        //}
        //    //call the ingredient id


        SpawnRecipe();
     


        

        // SpawnRandomObjects();

        isMatch = false;


    }

    List<int> RandomIngredientList()
    {

     List<int> tempList = new List<int>();
    
    // Loop to ensure we only get unique ingredient IDs
    while (tempList.Count < 3) // Assuming you want 3 ingredients
    {
        int randomIndex = Random.Range(0, ingredients.Count);
        if (!tempList.Contains(randomIndex)) // Ensure uniqueness
        {
            tempList.Add(randomIndex);
        }
    }

    //Shuffle(tempList);

    return tempList;

    }

    //void Shuffle(List<int> templist)
    //{
    //    for (int i = templist.Count - 1; i > 0; i--)
    //    {
    //        // Pick a random index from 0 to i
    //        int ingId = Random.Range(0, i + 1);
    //        // Swap templist[i] with the element at random index
    //        int temp = templist[MaxIngredients];
    //        templist[MaxIngredients] = templist[ingId];
    //        templist[ingId] = temp;
    //    }
    //}

    void SpawnIngredients()
    {
        //loop through the ingredients list
        for (int i = 0; i < ingredients.Count; i++)
        {

            //instatiate each prefab in the ingredient list
            GameObject tempObj = Instantiate(ingredients[i].prefab);

            //rename the object to the associated ingredient ID
            tempObj.name = i.ToString();

            //code to offset the ingredients
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + (i * 1), tempV3.y, tempV3.z);


        }
    }

    public void SpawnRecipe()
    {


        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);
            instance.name = "RecipeItems" + name;

            // Disable the collider to make it unclickable
            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the collider
            }

        }

     
    }

    private void Update()
    {

        if (!isRecipeActive && (GameObject.Find("RecipeItemsRecLoc2") == null || GameObject.Find("RecipeItemsRecLoc3") == null || GameObject.Find("RecipeItemsRecLoc1") == null))
        {
            Debug.Log("New Recipe Has Been Generated");
            SpawnRecipe();

        }

        

     
     
        

    }
    private void OnMouseDown()
    {
        if (!Timer.isTimerActive)
        {
            Debug.Log("Cannot click, timer has ended!");
            return; // Exit if the timer is not active
        }

        PanClick();

         
    }

    public void PanClick()
    {
        //SpawnRandomObjects();


        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
        // Destroy(GameObject.Find("RecLoc2"));
        // Find the parent object
        GameObject parent1 = GameObject.Find("RecLoc1");

        if (parent1 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent1.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }

        GameObject parent2 = GameObject.Find("RecLoc2");

        if (parent2 != null)
        {
            // Find the child objects and destroy them
            foreach (Transform child in parent2.transform)
            {
                Destroy(child.gameObject); // This will destroy the child clone
            }
        }

        GameObject parent3 = GameObject.Find("RecLoc3");

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

