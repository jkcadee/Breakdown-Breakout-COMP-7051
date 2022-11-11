using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

public class ScoreController : MonoBehaviour
{

    const string fileName = "/leaderboard.dat";

    public const int maxrank = 10;

    public List<float> highScores = new List<float>();

    public static ScoreController sCtrl;

    public void Awake()
    {
        if (sCtrl == null)
        {
            DontDestroyOnLoad(gameObject);
            sCtrl = this;
            LoadScore();
        }
    }

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

    public void SaveScore(float score)
    {
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
            temp[0] = highScores[i];
        }
        highScores = temp;
    }

    public void ResetScoreBoard() {

        for (int i = 0; i < highScores.Count; i++) {
            highScores[i] = 0.0f;
        }
        
    }

}

[Serializable]
class GameData
{
    public List<float> highScores = new List<float>();
};
