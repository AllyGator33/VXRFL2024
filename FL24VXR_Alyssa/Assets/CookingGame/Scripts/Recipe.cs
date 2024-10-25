using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Recipe : MonoBehaviour
{

    public string RecipeName;
    public int Recipeid;
    private Vector3 recipeSpawn = new Vector3(-2.32f, -0.5f, -6.4f);



    public Recipe(string _RecipeName, int _Recipeid)
    {
        //variable| new instance of variable
        RecipeName = _RecipeName;
        Recipeid = _Recipeid;

    }


    public void ChooseRecipe()
    {
        
    }


}
