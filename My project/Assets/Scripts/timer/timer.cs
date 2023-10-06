using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text bestTimerText;
    private float startTime;
    private bool finished = false;
    public static Timer instance;
    public float elapsedTime;

    private float bestTime =10  ; // Variable pour stocker le meilleur temps
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        // Charger le meilleur temps précédent depuis les préférences de joueur
        startTime = Time.time;
        bestTime = PlayerPrefs.GetFloat("BestTime");
        bestTimerText.text = "best time :" + bestTime.ToString("F2") + " secondes";
        bestTimerText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = "Timer :" + minutes + ":" + seconds;
    }

    public void Finish()
    {
        if (!finished)
        {
            timerText.color = Color.yellow;
            finished = true;
            // Comparaison avec le meilleur temps précédent
            elapsedTime = Time.time - startTime;
            if (bestTime == 0)
            {
                PlayerPrefs.DeleteKey("BestTime");
                PlayerPrefs.SetFloat("BestTime", elapsedTime);
                PlayerPrefs.Save();
            }
            else if (elapsedTime < bestTime)
            {
                bestTime = elapsedTime;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save(); // Sauvegarder les préférences
                Debug.Log("Temps actuel : " + elapsedTime + " secondes");
                Debug.Log("Meilleur temps : " + bestTime + " secondes");
            }
        }
    }
}
