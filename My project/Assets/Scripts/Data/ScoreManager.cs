using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public void LoadBestScores() {
        string json = File.ReadAllText(Application.dataPath + "/");
    }
}
