using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Recipe : MonoBehaviour
{

    public string RecipeName;
    public int Recipeid;
  
   

    public Recipe(string _RecipeName, int _Recipeid)
    {
        //variable| new instance of variable
        RecipeName = _RecipeName;
        Recipeid = _Recipeid;

    }



}
