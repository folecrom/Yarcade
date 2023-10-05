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
    private string data ="";
    private Score scoreData;
    

    public void Start() {
        // scoreData = new Score();
        // File.WriteAllText(Application.dataPath + "/HighscoreLvl1.json", JsonUtility.ToJson(scoreData, true));
    }
    public void Update() {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
            DisplayHighscores();
    }

    public void DisplayHighscores() {
        if (name == "LVL1")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl1.json");
        if (name == "LVL2")
            data = File.ReadAllText(Application.dataPath + "/HighScoreLvl2.json");
        scoreData = JsonUtility.FromJson<Score>(data);
        for (int i = 0; i < 5; i++) {
            scores[i].text = $"{scoreData.scores[i]}   :    {scoreData.usernames[i]}";
        }
    }
}
