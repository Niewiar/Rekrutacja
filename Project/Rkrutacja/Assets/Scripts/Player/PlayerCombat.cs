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
    [SerializeField] private Animator _hitAnimator;

    private Animator _animator;
    private InputManager _inputManager;
    private bool _isDead;
    private AudioManager _audio;

    [HideInInspector] public int health;
    [HideInInspector] public bool playerAttacking;

    private void Awake()
    {
        health = 3;
        playerAttacking = false;
        _animator = GetComponent<Animator>();
        _inputManager = GetComponent<InputManager>();
        atackTrigger.SetActive(false);
        _audio = FindObjectOfType<AudioManager>();
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
        health--;
        _hitAnimator.SetTrigger("Hit");
        _audio.Play("PlayerOugh");

        if (health <= 0)
        {
            health = 0;
            Dead();
        }

        _healthCounter.DestroyHeart(health);
    }
}
