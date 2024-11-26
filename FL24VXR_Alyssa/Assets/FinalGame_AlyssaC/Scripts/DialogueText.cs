using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{

    public TextMeshProUGUI theText;

    public GameObject textBox;

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
