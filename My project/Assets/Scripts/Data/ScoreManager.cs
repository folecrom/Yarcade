using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    
    public string username;
    public float score;
    public static ScoreManager instance;
    private string data ="";
    private Score scoreData;
    

    public void Start() {
        if (instance == null) {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void SetScore(string lvl) {
        Debug.Log(scoreData.scores[0]);
        var index = 5;
        Score newScoreData = new Score();
        for (int i = 4; i >= 0; i--) {
            if (score > scoreData.scores[i])
                index = i;
        }
        for (int y = 0; y <= 4; y++) {
            if (y < index)
            {
                newScoreData.scores[y] = scoreData.scores[y];
                newScoreData.usernames[y] = scoreData.usernames[y]; 
            }
            
        else if (y == index)
            {
                newScoreData.scores[y] = score; 
                newScoreData.usernames[y] = username; 
            }

            else
            {
                newScoreData.scores[y] = scoreData.scores[y]; 
                newScoreData.usernames[y] = scoreData.usernames[y]; 
            }
            
        }
        string json = JsonUtility.ToJson(newScoreData, true);
        if (lvl == "LVL1")
            File.WriteAllText(Application.dataPath + "/HighScoreLvl1.json", json);
        if (lvl == "LVL2")
            File.WriteAllText(Application.dataPath + "/HighScoreLvl2.json", json);
    }

    public void DisplayHighscores(UserManager lvl) {
        if (lvl.gameObject.name == "LVL1")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl1.json");
        if (lvl.gameObject.name == "LVL2")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl2.json");
        scoreData = JsonUtility.FromJson<Score>(data);
        for (int i = 0; i < 5; i++) {
            lvl.scores[i].text = $"{scoreData.usernames[i]}   :   {scoreData.scores[i]}";
        }
    }
}
