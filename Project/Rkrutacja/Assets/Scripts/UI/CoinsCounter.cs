using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    [HideInInspector] public int numberOfCoins;

    private void Awake()
    {
        _counterText.SetText(numberOfCoins.ToString());
    }

    public void AddCoin()
    {
        numberOfCoins++;
        SetText();
    }

    public void SetText()
    {
        _counterText.SetText(numberOfCoins.ToString());
    }
}
