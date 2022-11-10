using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Timer : MonoBehaviour
{

    public float time;
    public TextMeshProUGUI timer_text;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 2;
        int time_integer = (int)time;
        int minute = time_integer / 60;
        int seconds = time_integer % 60;
        if (seconds < 10)
        {
            timer_text.text = minute + ":0" + seconds;
        }
        else {
            timer_text.text = minute + ":" + seconds;
        }
    }
}
