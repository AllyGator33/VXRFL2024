using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour

{

    
    [SerializeField] float timerValue = 30;

    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        StartCoroutine(BeginTimer());
    }

    IEnumerator BeginTimer()
    {
        while (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = "Time: " + (int)timerValue;
            yield return null;
        }
        timerText.text = "Time: 0";
   }
}

