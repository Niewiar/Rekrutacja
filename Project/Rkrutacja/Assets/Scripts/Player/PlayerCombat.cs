using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
public class PlayerCombat : MonoBehaviour
{
    public GameObject atackTrigger;

    private Animator _animator;
    private InputManager _inputManager;

    [HideInInspector] public bool playerAttacking;

    private void Awake()
    {
        playerAttacking = false;
        _animator = GetComponent<Animator>();
        _inputManager = GetComponent<InputManager>();
        atackTrigger.SetActive(false);
    }

    private void Update()
    {
        if (_inputManager.AtackButtonWasClicked() && !playerAttacking)
        {
            playerAttacking = true;
            atackTrigger.SetActive(true);
            _animator.SetTrigger("Attack");
        }
    }
}
