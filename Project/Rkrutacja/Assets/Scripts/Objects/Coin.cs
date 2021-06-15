using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinsCounter coinsCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            coinsCounter.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
