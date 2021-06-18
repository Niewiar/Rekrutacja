using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Transform _lockOn;
    [SerializeField] private EnemieCombat _enemieCombat;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _enemieCombat.health;
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_lockOn.position);
        _slider.value = _enemieCombat.health;
    }
}
