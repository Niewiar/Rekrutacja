using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemieAi))]
[RequireComponent(typeof(Animator))]
public class EnemieCombat : MonoBehaviour
{
    [Header("Enemy stats")]
    [SerializeField] private int _health;
    [Header("Repulse target")]
    [SerializeField] private bool _canRepulseTarget;
    [SerializeField] private float _horizontalRepulseForce = 100f;
    [SerializeField] private float _verticalRepulseForce = 500f;
    [SerializeField] private float _timeToUnlockTargetMovement = 0.7f;

    private Animator _animator;
    private EnemieAi _enemieAi;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemieAi = GetComponent<EnemieAi>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RepulseTarget(collision.gameObject);
            collision.gameObject.GetComponent<PlayerCombat>().TakeDamage();
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
        }
    }

    private void TakeDamage()
    {
        _health--;
        _enemieAi.hit = true;
        _animator.SetTrigger("Hit");

        if (_health == 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        _enemieAi.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        _animator.SetTrigger("Dead");
    }
}
