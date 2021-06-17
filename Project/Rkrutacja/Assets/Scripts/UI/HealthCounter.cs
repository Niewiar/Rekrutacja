using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Animator[] _heartAnimators;
    [SerializeField] private GameObject[] _emptyHearts;
    [SerializeField] private Image[] heartsImage;

    public void DestroyHeart(int numberOfHealth)
    {
        _heartAnimators[numberOfHealth].SetTrigger("Hit");
        _emptyHearts[numberOfHealth].SetActive(true);
    }

    public void LoadHealth(int value)
    {
        switch (value)
        {
            case 1:
                foreach (var item in heartsImage)
                {
                    item.enabled = false;
                }
                _emptyHearts[2].SetActive(true);
                _emptyHearts[1].SetActive(true);
                break;
            case 2:
                heartsImage[0].enabled = false;
                _emptyHearts[2].SetActive(true);
                break;
            default:
                break;
        }
    }
}
