using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanLogic : MonoBehaviour
{
    [SerializeField]
    RecipeBook recipeBook;

    private void OnMouseDown()
    {

    }

    public void StartCountDown(int _min, int _max)
    {

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
    }
}


