using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{

    public TextMeshProUGUI theText;

    public GameObject textBox;

    public Transform player; // Reference to the player's Transform
    public bool onlyHorizontal = true; // Whether to restrict the rotation to the Y-axis (optional)

    //public Text thetext;


    public TextAsset BugzyText;
    public string[] textlines;

    public int currentLine;
    public int endALine;


    // Start is called before the first frame update
    void Start()
    {
        if (BugzyText != null)
        {
            textlines = (BugzyText.text.Split('\n'));
        }

        if (endALine == 0)
        {
            endALine = textlines.Length - 1;
        }

    }

    private void Update()
    {
        theText.text = textlines[currentLine];

        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned!");
            return;
        }

        // Calculate the direction vector from the sprite to the player
        Vector3 direction = player.position - transform.position;

        if (onlyHorizontal)
        {
            // Ignore vertical differences by zeroing out the Y component
            direction.y = 0f;
        }

        // Update the rotation to look at the player
        transform.rotation = Quaternion.LookRotation(direction);

    }

    public void nextLine()
    {
        currentLine += 1;

        if (currentLine > endALine)
        {
            textBox.SetActive(false);
        }
    }
    // Start is called before the first frame update
}
