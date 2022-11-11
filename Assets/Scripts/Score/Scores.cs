using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        string mainText = "";
        if (ScoreController.sCtrl.highScores.Count != 0) {
            for (int i = 0; i < ScoreController.sCtrl.highScores.Count; i++)
            {
                int time_integer = (int)ScoreController.sCtrl.highScores[i];
                int minute = time_integer / 60;
                int seconds = time_integer % 60;
                if (seconds < 10)
                {
                    mainText += (i + 1) + "." + minute + ":0" + seconds + "\n";
                }
                else
                {
                    mainText += (i + 1) + "." + minute + ":" + seconds + "\n";
                }
            }
        }
        text.text = mainText;
    }
}
