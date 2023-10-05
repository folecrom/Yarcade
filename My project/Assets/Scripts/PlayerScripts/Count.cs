using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public int coinsCount;
    public static Count instance;
    public GameObject coinSprite;
    public GameObject coinSprite1;
    public GameObject coinSprite2;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("vous avez toutes les pieces");
            return ;
        }
        instance = this;
    }
    public void AddCoins(int counte){
        coinsCount += counte;
        if (coinsCount == 1)
        {
            coinSprite.SetActive(true);
        }
        else if (coinsCount == 2)
        {
            coinSprite1.SetActive(true);
        }
        else if (coinsCount == 3)
        {
            coinSprite2.SetActive(true);
        }
        else
        {
            Debug.LogError("Vous n'avez pas de pièces.");
        }
    }
     private void ShowCoinSprite()
    {
        if (coinSprite != null)
        {
            coinSprite.SetActive(true); // Activez l'objet GameObject/Image pour afficher le sprite.
        }
        else
        {
            Debug.LogError("La référence à l'objet coinSprite n'a pas été attribuée.");
        }
    }
}
