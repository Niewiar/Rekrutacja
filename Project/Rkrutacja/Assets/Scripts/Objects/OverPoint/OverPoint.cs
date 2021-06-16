using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _jumpIndicators;

    private void Awake()
    {
        DesactiveJumpIndicators();
    }

    public void ActivateJumpIndicators()
    {
        foreach (var item in _jumpIndicators)
        {
            item.SetActive(true);
        }
    }

    public void DesactiveJumpIndicators()
    {
        foreach (var item in _jumpIndicators)
        {
            item.SetActive(false);
        }
    }
}
