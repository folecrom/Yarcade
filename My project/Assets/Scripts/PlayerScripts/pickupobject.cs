
using UnityEngine;

public class pickupobject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Count.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
