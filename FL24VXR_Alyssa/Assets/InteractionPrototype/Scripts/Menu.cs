using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas; // Reference to the Canvas

    public void HideMenu()
    {
        // Deactivate the Canvas
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);//Hides the canvas
        }
    }
}