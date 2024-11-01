using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


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
   [SerializeField] public List<Recipe> recipes = new List<Recipe>();
    //public RecipeManager recipeManager;
    bool isMatch = false;
    public static int MaxIngredients = 1;

   

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


        InstantiateRandomPrefabs();

       // SpawnRandomObjects();

        isMatch = false;


    }

    List<int> RandomIngredientList()
    {

        List<int> tempList = new List<int>();
        //loop through using the Recipe.MaxIngredients static variable as the count limit
        //randomly add an ingredient ID using the ingredient list count as the loop limit
        for (int i = 0; i < Recipe.MaxIngredients; i++)
        {
            int randomIndex = Random.Range(0, ingredients.Count);
            tempList.Add(Random.Range(0, ingredients.Count - 1));

        }

        Shuffle(tempList);

        return tempList;

    }

    void Shuffle(List<int> templist)
    {
      
    }

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

    public void InstantiateRandomPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            GameObject instance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);

            // Disable the collider to make it unclickable
            Collider collider = instance.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Disable the collider
            }


        }


    }

   
    void ChooseIngredient(int ingredientID)
    {

    }

    void SpawnRecipe()
    {

    }


    void CalculateEarnings()
    {
        // if (!RecipeBook.earningsIncrease)
        if (isMatch)
        {
            Debug.Log("Game Over! Try Again.");
        }
        else
        {
            Debug.Log("Game is still ongoing.");
        }

        // Example of changing the boolean
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMatch = true; // Change the boolean value when the space key is pressed
        }
    }

    public void PanClick()
    {
        //SpawnRandomObjects();

        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
       // Destroy(GameObject.Find("RecLoc1"));
       // Destroy(GameObject.Find("RecLoc2"));
       

    }

    private void OnMouseDown()
    {

        PanClick();
        // Call to replace on click
    }

    //private void SpawnRandomObjects()
    //{
    //    // Create a HashSet to keep track of instantiated indices (to avoid duplicates)
    //    List<int> selectedIngredients = new List<int>();

    //    // Attempt to select three unique indices
    //    while (selectedIngredients.Count < 3 && selectedIngredients.Count < prefabsToInstantiate.Count)
    //    {
    //        int randomIndex = Random.Range(0, prefabsToInstantiate.Count);
    //        selectedIngredients.Add(randomIndex);
    //    }

    //    // Instantiate the selected GameObjects
    //    foreach (int index in selectedIngredients)
    //    {
    //        // You can modify the position as needed
    //        Vector3 spawnPosition = transform.position + new Vector3(0, 0, index); // Staggered in the Z-axis
    //        Instantiate(prefabsToInstantiate[index], spawnPosition, Quaternion.identity);
    //    }
    //}

}
