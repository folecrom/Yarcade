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
    [SerializeField] private Text[] scores;
    public string username;
    public static ScoreManager instance;
    private string data ="";
    private Score scoreData;
    

    public void Start() {
        if (instance == null) {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void DisplayHighscores(string lvl) {
        if (lvl == "LVL1")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl1.json");
        if (lvl == "LVL2")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl2.json");
        scoreData = JsonUtility.FromJson<Score>(data);
        for (int i = 0; i < 5; i++) {
            scores[i].text = $"{scoreData.scores[i]}   :    {scoreData.usernames[i]}";
        }
    }
}
