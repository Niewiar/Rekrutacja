using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PlayerController))]
public class PlayerCombat : MonoBehaviour
{
    public GameObject atackTrigger;
    [SerializeField] private HealthCounter _healthCounter;

    private Animator _animator;
    private InputManager _inputManager;
    private int _health;
    private bool _isDead;

    [HideInInspector] public bool playerAttacking;

    private void Awake()
    {
        _health = 3;
        playerAttacking = false;
        _animator = GetComponent<Animator>();
        _inputManager = GetComponent<InputManager>();
        atackTrigger.SetActive(false);
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (_inputManager.AtackButtonWasClicked() && !playerAttacking)
        {
            playerAttacking = true;
            atackTrigger.SetActive(true);
            _animator.SetTrigger("Attack");
        }
    }

    private void Dead()
    {
        if (!_isDead)
        {
            _isDead = true;
            GetComponent<PlayerController>().enabled = false;
            _animator.SetTrigger("Dead");
        }
    }

    public void TakeDamage()
    {
        _health--;

        if (_health <= 0)
        {
            _health = 0;
            Dead();
        }

        _healthCounter.DestroyHeart(_health);
    }
}
