using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecipeBook : MonoBehaviour
{

    //syntax for list is <>, name of,   setting new values
  public List<Ingredients> ingredients = new List<Ingredients>();
    public List<RecipeBook> recipes = new List<RecipeBook>();
    public List<int> usedIngredient = new List<int>();

    void Start()
    {
        ingredients.Add(new Ingredients("Cube Red", 0, Resources.Load("Ingredients/CubeRed") as GameObject, 3));
        ingredients.Add(new Ingredients("Sphere Blue", 0, Resources.Load("Ingredients/SphereBlue") as GameObject, 4));
        ingredients.Add(new Ingredients("Sphere Orange", 0, Resources.Load("Ingredients/SphereOrange") as GameObject, 5));
        ingredients.Add(new Ingredients("Green Cube", 0, Resources.Load("Ingredients/GreenCube") as GameObject, 6));
        ingredients.Add(new Ingredients("Cylinder Pink", 0, Resources.Load("Ingredients/CylinderPink") as GameObject, 7));
    }

 //   void SpawnIngredients();
 //   {
   // for (int i = 0; i < Ingredients.Count; i++)
   //     {

        //instatiate each prefab in the ingredient list
     //   Game Object tempObj = Instantiate(Ingredients[i].prefab);

    //rename the object to the associated ingredient ID
 //   tempObj.name = i.ToString();

        //code to offset the ingredients
      //  Vector3 tempV3 = tempObj.transform.position;
  //  tempObj.transform.position = new Vector3(tempyV3.x + (int * 1), tempV3.y, tempV3.z);
}
