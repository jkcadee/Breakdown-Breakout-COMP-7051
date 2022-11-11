using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

public class ScoreController : MonoBehaviour
{
    //Where this data is stored.
    const string fileName = "/leaderboard.dat";

    //The maximum number of scores on the ranking list (top 10)
    public const int maxrank = 10;

    //The list of high scores (there should only be 10 entries)
    public List<float> highScores = new List<float>();

    //The ScoreController object
    public static ScoreController sCtrl;

    /** Initializes the script when the game starts.*/
    public void Awake()
    {
        if (sCtrl == null)
        {
            DontDestroyOnLoad(gameObject);
            sCtrl = this;
            LoadScore();
        }
    }
    
    /** 
     Loads the score values that have been saved.
     */
    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read);
            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();
            highScores = data.highScores;
        }
    }
    /** 
     Saves a float value into the highscores if it is high enough
    @param float
     */ 
    public void SaveScore(float score)
    {
        //If the list of high scores is empty, just insert into the first entry
        if (highScores.Count == 0) {
            highScores.Insert(0, score);
        } else {
            for (int i = 0; i < highScores.Count; i++) {
                if (highScores[i] < score) {
                    highScores.Insert(i, score);
                    if (highScores.Count > maxrank) {
                        CutList();
                    }
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
                    GameData data = new GameData();
                    data.highScores = highScores;
                    bf.Serialize(fs, data);
                    fs.Close();
                    break;
                }
            }
        }
               
    }

    public void CutList() {
        List<float> temp = new List<float>();
        for (int i = 0; i < maxrank; i++) {
            temp.Insert(i, highScores[i]);
        }
        highScores = temp;
    }

    public void ResetScoreBoard() {

       highScores = new List<float>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
        GameData data = new GameData();
        data.highScores = highScores;
        bf.Serialize(fs, data);
        fs.Close();

    }

}

[Serializable]
class GameData
{
    public List<float> highScores = new List<float>();
};
