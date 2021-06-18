using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemieAi))]
[RequireComponent(typeof(Animator))]
public class EnemieCombat : MonoBehaviour
{
    [Header("Enemy stats")]
    public int health;
    [SerializeField] private GameObject _healthBar;
    [Header("Repulse target")]
    [SerializeField] private bool _canRepulseTarget;
    [SerializeField] private float _horizontalRepulseForce = 100f;
    [SerializeField] private float _verticalRepulseForce = 500f;

    private Animator _animator;
    private EnemieAi _enemieAi;
    private AudioManager _audio;

    private void Awake()
    {
        _audio = FindObjectOfType<AudioManager>();
        _animator = GetComponent<Animator>();
        _enemieAi = GetComponent<EnemieAi>();
        _healthBar.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RepulseTarget(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttackTrigger")
        {
            TakeDamage();
        }
    }

    private void RepulseTarget(GameObject target)
    {
        if (_canRepulseTarget)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction = direction.normalized;
            target.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * _horizontalRepulseForce, direction.y * _verticalRepulseForce));
            target.GetComponent<PlayerCombat>().TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _healthBar.SetActive(true);
        health--;
        _enemieAi.hit = true;
        _animator.SetTrigger("Hit");
        _audio.Play("EnemyOugh");

        if (health == 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        _healthBar.SetActive(false);
        _enemieAi.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        _animator.SetTrigger("Dead");
    }
}
