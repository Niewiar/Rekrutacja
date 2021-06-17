using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _loadData;
    [SerializeField] private GameData _gameData;
    public int enemiesOnLvl;
    [SerializeField] private GameObject _sceneVase;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private HealthCounter _healthCounter;
    [SerializeField] private PlayerCombat _player;

    private bool _vaseActive;

    private void Awake()
    {
        _vaseActive = false;
        _sceneVase.SetActive(false);
        _sceneVase.GetComponent<Vase>().gameManager = this;

        if (_loadData)
        {
            _coinsCounter.numberOfCoins = _gameData.collectedCoins;
            _coinsCounter.SetText();
            _player.health = _gameData.playerLife;
            _healthCounter.LoadHealth(_gameData.playerLife);
        }
    }

    private void Update()
    {
        if (enemiesOnLvl == 0 && !_vaseActive)
        {
            _vaseActive = true;
            _sceneVase.SetActive(true);
        }
    }

    public void SaveData()
    {
        _gameData.collectedCoins = _coinsCounter.numberOfCoins;
        _gameData.playerLife = _player.health;
    }
}
