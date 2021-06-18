using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinsCounter coinsCounter;
    [Header("Coin magnes settings")]
    [SerializeField] private bool _magnesCoin;
    [SerializeField] private float _magnesCoinRayRadius = 2f;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private float _speed;

    private Transform _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            coinsCounter.AddCoin();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (_magnesCoin)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _magnesCoinRayRadius, _whatIsPlayer);

            if (colliders != null && _player == null)
            {
                foreach (var item in colliders)
                {
                    if (item != null)
                    {
                        _player = item.gameObject.transform;
                    }
                }
            }

            if (_player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, Time.deltaTime * _speed);
            }
        }
    }
}
