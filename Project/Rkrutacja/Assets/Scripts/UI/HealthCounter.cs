using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Animator[] _heartAnimators;
    [SerializeField] private GameObject[] _emptyHearts;

    public void DestroyHeart(int numberOfHealth)
    {
        _heartAnimators[numberOfHealth].SetTrigger("Hit");
        _emptyHearts[numberOfHealth].SetActive(true);
    }
}
