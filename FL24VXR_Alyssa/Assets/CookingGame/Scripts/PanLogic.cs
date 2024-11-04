using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class PanLogic : MonoBehaviour
{

    public RecipeBook recipebook; //call RecipeBook script

    [SerializeField] float earningsValue = 0; //makes the earnings value start $0

    [SerializeField] TextMeshProUGUI EarningsText; //

    public static bool GenerateEarnings = false;  //makes the bool start as false

    public List<Ingredients> ingredients; // List of ingredients

    private void Start()
    {
        GenerateEarnings = false; //bool starts as false
    }
    void OnMouseDown()
    {

        {
        
            CalculateEarnings();    //calls on calculate earnings method when mouse is clicked
            UpdateEarningsText();  //calls on update earnings text method when mouse is clicked 

        }

    }

    void CalculateEarnings() //method used to check and compare game objects and then calculate earnings 
    {
        if (!GenerateEarnings)
        {
            Debug.Log("Wrong!");//debug log to check if code works
        }
        else
        {
            GenerateEarnings = true; // Allow earnings to be generated

            {
      
                GameObject panItem = GameObject.Find("Pan Item 1"); // Find the Pan Item in the scene, give it a name

                if (panItem != null) //if pan item is not empty 
                {
                   
                    Ingredients matchingIngredient = recipebook.ingredients.Find(ingredient => ingredient.prefab == panItem);  // Check for matching ingredient in the ingredients list

                    if (matchingIngredient != null)//if matching ingredient is not empty
                    {
                        earningsValue += matchingIngredient.dollarValue; // Add dollarValue of the matching ingredient to earningsValue
                    }
                }

            }

            UpdateEarningsText(); // Update the UI text with the updated earnings value
        }
    }

    private void UpdateEarningsText()
    {
        EarningsText.text = "Earnings: $" + earningsValue; // Update the UI text with current earnings
    }

}



