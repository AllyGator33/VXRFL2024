using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe 
{
 // Assign your prefabs in the Inspector
    public string RecipeName; //creates a public variable for the recipes name
    public int Recipeid; //creates a public variable for the recipe id
    public List<int> ingredientsID; //creates ingredient ID list
    public static int maxNumber = 3; //defined max number of ingredients

    public Recipe(string _name, int _id, List<int> _ingredientsID ) //constructor to define stuff included in recipe
    {
        //variable| new instance of variable
        RecipeName = _name;  //creates recipe name for constructor
        Recipeid = _id;  //creates recipe id for constructor
        ingredientsID = _ingredientsID;  //creates ingredients id for constructor
    }

}
