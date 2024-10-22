using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// no monobehvaiour so that you can use the constructor. Monobehaviour attaches something
//to a gameobject, so without a monobehaviour it cannot be attached to a game object

//in order to be used in other scripts there needs to be no monobehaviour 
public class Ingredients 
{
    public string name;
    public int id;
    public GameObject prefab;
    public int dollarValue;


    //constructor for ingredient class
    //must be public is so it can be recalled in a different script
    public Ingredients(string _name, int _id, GameObject _prefab, int _dollarValue)
    {
    //variable| new instance of variable
        name = _name;
        id = _id;
        prefab = _prefab;
        dollarValue = _dollarValue;
    }
}
