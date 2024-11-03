using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickNew : MonoBehaviour
{

    //shared across multiple game objects in the scene

    //reference click count when finding correctness of recipe in pan
    public static int clickCount = 0;
    public static int MaxIngredients = 3;

    private void OnMouseDown()
    {

        if (!Timer.isTimerActive)
        {
            Debug.Log("Cannot click, timer has ended!");
            return; // Exit if the timer is not active
        }

        clickCount++;
        Transform moveLoc;
        //tmp = temporary name, cuz it wont always be the same object
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<ItemClickNew>());

        //switches are used if if statements are not very efficient; first case, second case, third case, etc
        switch (clickCount)
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("PanLoc1").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                //syntax to include in order to jump from your first case to your second place
                break;

            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("PanLoc2").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;


            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("PanLoc3").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                break; 
        }

    }

     void Update()
    {
        if (GameObject.Find("Pan Item 1") == null)
                clickCount = 0;
    }
}
