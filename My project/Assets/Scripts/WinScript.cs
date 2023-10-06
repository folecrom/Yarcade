using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    [SerializeField] private Canvas finishCanvas;
    [SerializeField] private float rawScoreFinish;
    [SerializeField] private Text scoreText;
    public float score;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Count.instance.coinsCount == 3)
        {
            finishCanvas.gameObject.SetActive(true);
            Timer.instance.Finish();
            var time = Timer.instance.elapsedTime;
            score = rawScoreFinish * (1 / time);
            ScoreManager.instance.score = score;
            scoreText.text = $"Your score : {score}";
            ScoreManager.instance.SetScore(GameManager.instance.lvl);
        }
    }
}
