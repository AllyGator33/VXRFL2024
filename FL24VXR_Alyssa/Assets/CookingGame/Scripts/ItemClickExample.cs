using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickExample : MonoBehaviour
{
  
    //shared across multiple game objects in the scene

    //reference click count when finding correctness of recipe in pan
    public static int clickCount = 0;

    private void OnMouseDown()
    {
        clickCount++;
        Transform moveLoc;
        //tmp = temporary name, cuz it wont always be the same object
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<ItemClickExample>());

        //switches are used if if statements are not very efficient; first case, second case, third case, etc
        switch (clickCount)
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("RecLoc1").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                //syntax to include in order to jump from your first case to your second place
                break;

            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("RecLoc2").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;


            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("RecLoc3").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                clickCount = 0;
                break;
           } 
        }
}
