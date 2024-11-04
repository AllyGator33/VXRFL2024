using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickNew : MonoBehaviour
{

    //reference click count when finding correctness of recipe in pan
    public static int clickCount = 0; //defines starting integer amount for click count 
    public static int MaxIngredients = 3; //variable for the max number of ingredients

    private void OnMouseDown()
    {
        if (!Timer.isTimerActive) //checking to see if the timer is activ, if it's not, you can't click anymore
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
                tmp.name = "Pan Item 1"; //finds PanLoc1 locations and makes a moveLoc that can be called on when mouse is clicked
                moveLoc = GameObject.Find("PanLoc1").transform; 

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //changes the gameobject scale after moving it
          
                break; //the syntax to include in order to jump from your first case to your second place

            case 2:
                tmp.name = "Pan Item 2"; //gives the instantiated gameobject a temporary name so i can call on it later if needed
                moveLoc = GameObject.Find("PanLoc2").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //changes the gameobject scale after moving it
                break; //the syntax to include in order to jump from your first case to your second place


            case 3:
                tmp.name = "Pan Item 3"; //gives the instantiated gameobject a temporary name so i can call on it later if needed
                moveLoc = GameObject.Find("PanLoc3").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //changes the gameobject scale after moving it

                break; //the syntax to include in order to jump from your first case to your second place
        }

    }

     void Update()
    {
        if (GameObject.Find("Pan Item 1") == null) //if the panItem1 gameObject is null, the click count gets resetted to be able to keep putting objects onto the pan after they get removed from it 
                clickCount = 0;
    }
}
