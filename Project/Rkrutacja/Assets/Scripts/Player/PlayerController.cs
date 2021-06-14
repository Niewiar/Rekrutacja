using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement options values")]
    [SerializeField] [Range(1, 10)] private float _speed = 3;
    [SerializeField] [Range(100, 1000)] private float _jumpForce = 500;

    private InputManager _inputManager;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private GroudChecker _groudChecker;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _groudChecker = GetComponentInChildren<GroudChecker>();
    }

    private void FixedUpdate()
    {
        MovePlayer();   
    }

    private void MovePlayer()
    {
        if (_inputManager.SideMoveValue() < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        _animator.SetFloat("Speed", Mathf.Abs(_inputManager.SideMoveValue()));

        Vector3 direction = transform.position + Vector3.right * _inputManager.SideMoveValue();
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * _speed);
    }

    public void Jump()
    {
        if (_groudChecker.grounded && _inputManager.JumpButtonWasClicked())
        {
            _rb.AddForce(new Vector2(0f, _jumpForce));
        }
    }
}
