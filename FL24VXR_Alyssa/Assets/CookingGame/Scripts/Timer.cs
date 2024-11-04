using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour

{

    [SerializeField] float timerValue = 30; //makes the timer start at 30 seconds 

    [SerializeField] TextMeshProUGUI timerText; //creates the ability to update the text string later

    // Static variable to indicate if the timer is active
    public static bool isTimerActive = true;

    void Start()
    {
        StartCoroutine(BeginTimer()); //starts the couroutine for the timer
    }

    IEnumerator BeginTimer() //begins the timer
    {
        while (timerValue >= 0) //while timer value is counting down
        {
            timerValue -= Time.deltaTime; 
            timerText.text = "Time: " + (int)timerValue; //finds the UI text and adds the timervalue to it
            yield return null;  //returns a value
        }
        timerText.text = "Time: 0";
        isTimerActive = false; // Timer has ended
    }
}

