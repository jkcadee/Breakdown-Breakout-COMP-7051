using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostRunTimeDisplay : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        //Saves the current score into the game
        ScoreController.sCtrl.SaveScore(Level_Timer.GetTime());
        text.text = Level_Timer.GetTime() + " seconds";
    }
}
