using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class PanLogic : MonoBehaviour
{

    public RecipeBook recipebook;

    [SerializeField]
    RecipeBook recipeBook;

    [SerializeField] float earningsValue = 0;

    [SerializeField] TextMeshProUGUI EarningsText;

    public static bool GenerateEarnings = false;


    //generate earnings
    // call recipe book to make new recipe

    void OnMouseDown()
    {

        {
           // recipes.Shuffle(5);
            IncreaseEarnings();
            UpdateEarningsText();
            // Optionally call a method to generate a recipe here if needed
        }

    }

    private void IncreaseEarnings()
    {
        earningsValue += 10; // Increment earnings by 10
    }

    private void UpdateEarningsText()
    {
        EarningsText.text = "Earnings: " + earningsValue; // Update the UI text with current earnings
    }
}



