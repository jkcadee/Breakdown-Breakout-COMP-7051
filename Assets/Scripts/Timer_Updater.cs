using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_Updater : MonoBehaviour
{
    //A text object that displays the text
    public TextMeshProUGUI timer_text;

    // Start is called before the first frame update
    void Start()
    {
        int time_integer = (int)Level_Timer.GetTime();
        int minute = time_integer / 60;
        int seconds = time_integer % 60;
        if (seconds < 10)
        {
            timer_text.text = minute + ":0" + seconds;
        }
        else
        {
            timer_text.text = minute + ":" + seconds;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int time_integer = (int)Level_Timer.GetTime();
        int minute = time_integer / 60;
        int seconds = time_integer % 60;
        if (seconds < 10)
        {
            timer_text.text = minute + ":0" + seconds;
        }
        else
        {
            timer_text.text = minute + ":" + seconds;
        }
    }
}
