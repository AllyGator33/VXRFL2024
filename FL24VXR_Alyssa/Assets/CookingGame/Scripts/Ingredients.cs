using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// no monobehvaiour so that you can use the constructor. Monobehaviour attaches something
//to a gameobject, so without a monobehaviour it cannot be attached to a game object

//in order to be used in other scripts there needs to be no monobehaviour 
public class Ingredients 
{
    public string name; //defines name variable
    public int id; //defines id variable
    public GameObject prefab; //defines a GameObject variable named prefab 
    public int dollarValue; //defines and integer named dollarValue


    //constructor for ingredient class
    //must be public is so it can be recalled in a different script
    public Ingredients(string _name, int _Ingid, GameObject _prefab, int dollarValue) //constructor to define stuff included in Ingredients
    {
    //variable| new instance of variable
        name = _name; //creates names for constructor
        id = _Ingid; //creates ingredient id for constructor
        prefab = _prefab; //creates prefab for constructor 
        this.dollarValue = dollarValue; //creates dollarValue for constructor
    }
}
