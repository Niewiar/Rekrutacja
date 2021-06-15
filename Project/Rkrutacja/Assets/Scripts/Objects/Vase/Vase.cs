using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Vase : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _maxCoinsNumber = 5;
    [SerializeField] private CoinsCounter _coinsCounter;

    private BoxCollider2D _boxCollider;
    private Animator _animator;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttackTrigger")
        {
            _boxCollider.enabled = false;
            _animator.SetTrigger("Break");
        }
    }

    public void GenerateCoins()
    {
        int numberOfCoins = Random.Range(1, _maxCoinsNumber + 1); //_maxCoinsNumber + 1 because Random.Range doesn't return max number value to roll

        for (int i = 0; i < numberOfCoins; i++)
        {
            var obj = Instantiate(_coinPrefab);
            obj.transform.position = transform.position;
            obj.GetComponent<Coin>().coinsCounter = this._coinsCounter;
        }

        Destroy(this.gameObject);
    }
}
