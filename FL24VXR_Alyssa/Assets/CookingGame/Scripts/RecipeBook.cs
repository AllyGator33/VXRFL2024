using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecipeBook : MonoBehaviour
{

    //syntax for list is <>, name of,   setting new values
    public List<Ingredients> ingredients = new List<Ingredients>();
    public List<RecipeBook> recipes = new List<RecipeBook>();
    public List<int> usedIngredient = new List<int>();
    //public List<Recipe> RandomIngredientList(int numberOfIngredients = 3);

    // List of all possible ingredients
    private List<Recipe> allIngredients = new List<Recipe>
    {


    };

    void Start()
    {
        ingredients.Add(new Ingredients("Cube Red", 0, Resources.Load("Ingredients/CubeRed") as GameObject, 3));
        ingredients.Add(new Ingredients("Sphere Blue", 0, Resources.Load("Ingredients/SphereBlue") as GameObject, 4));
        ingredients.Add(new Ingredients("Sphere Orange", 0, Resources.Load("Ingredients/SphereOrange") as GameObject, 5));
        ingredients.Add(new Ingredients("Green Cube", 0, Resources.Load("Ingredients/GreenCube") as GameObject, 6));
        ingredients.Add(new Ingredients("Cylinder Pink", 0, Resources.Load("Ingredients/CylinderPink") as GameObject, 7));

        Resources.Load<GameObject>("Prefabs/CubeRed");
        Resources.Load<GameObject>("Prefabs/GreenCube");
        Resources.Load<GameObject>("Prefabs/SphereBlue");
        Resources.Load<GameObject>("Prefabs/SphereOrange");
        Resources.Load<GameObject>("Prefabs/CylinderPink");


        List<Recipe> recipes = new List<Recipe>();

        // Create a new recipe with a random ingredient list
        // recipes.Add(new Recipe("Recipe 1", 0, RandomIngredientList(), 3));


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

    void CalculateEarnings(bool gain)
    {

    }

    void ChooseIngredient(int ingredientID)
    {

    }

    void ChooseRecipe()
    {

    }

    private void ResetPan()
    {

    }

}
