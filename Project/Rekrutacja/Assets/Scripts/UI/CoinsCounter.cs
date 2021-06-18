using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private AudioManager _audioManager;

    [HideInInspector] public int numberOfCoins;

    private void Awake()
    {
        _counterText.SetText(numberOfCoins.ToString());
    }

    public void AddCoin()
    {
        _audioManager.Play("Coin");
        numberOfCoins++;
        SetText();
    }

    public void SetText()
    {
        _counterText.SetText(numberOfCoins.ToString());
    }
}
