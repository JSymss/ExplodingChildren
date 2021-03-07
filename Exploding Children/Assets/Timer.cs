using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;

   
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Time.time - startTime;
        //Stop counting if time is at 10 seconds
        if (Time.time - startTime >= 10)
            return;
        //Change colour at 5 seconds
        if (Time.time - startTime >= 5)
            timerText.color = Color.yellow;
        //Display time to 1 decimal point as text string
        string p = (10 - t).ToString("f1");
        timerText.text = p;
    }
}
