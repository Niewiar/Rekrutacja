using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemiesOnLvl;
    [SerializeField] private GameObject _sceneVase;

    private bool _vaseActive;

    private void Awake()
    {
        _vaseActive = false;
        _sceneVase.SetActive(false);
    }

    private void Update()
    {
        if (enemiesOnLvl == 0 && !_vaseActive)
        {
            _vaseActive = true;
            _sceneVase.SetActive(true);
        }
    }
}
