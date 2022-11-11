using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTesting : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float currentScore;

    void Start() {

        currentScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + currentScore;
    }

    public void IncScore() {

        currentScore++;

        ScoreController.sCtrl.SaveScore(currentScore);
    
    }

    public void DecScore()
    {

        currentScore--;
        ScoreController.sCtrl.SaveScore(currentScore);
    }

    public void Reset() {
        ScoreController.sCtrl.ResetScoreBoard();
    }
}
