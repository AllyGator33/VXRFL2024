using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe 
{
 // Assign your prefabs in the Inspector
    public string RecipeName;
    public int Recipeid;
    public List<int> ingredientsID;
    public string recipe;
    public GameObject prefab;
    public static int maxNumber = 3;
   
    


    // public Recipe(string _RecipeName, int _Recipeid)
    //  {
    //variable| new instance of variable
    //    RecipeName = _RecipeName;
    //     Recipeid = _Recipeid;

    // }


    public Recipe(string _name, int _id, List<int> _ingredientsID )
    {
        //variable| new instance of variable
        RecipeName = _name;
        Recipeid = _id;
        ingredientsID = _ingredientsID;
    }



}
