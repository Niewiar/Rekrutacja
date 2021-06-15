using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Ground checker options")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkerRadius;
    [Header("Movement options values")]
    [SerializeField] [Range(1, 10)] private float _speed = 3;
    [SerializeField] [Range(100, 1000)] private float _jumpForce = 500;
    [SerializeField] private Transform _attackTrigger;

    private InputManager _inputManager;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _grounded;

    [HideInInspector] public bool playerIsJumping;
    [HideInInspector] public bool checkYAxis;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        GroundCheck();
        ActivateJump();
    }

    private void MovePlayer()
    {
        if (_inputManager.SideMoveValue() < 0)
        {
            _spriteRenderer.flipX = true;
            _attackTrigger.localEulerAngles = new Vector3(0, -180, 0);
        }
        else if (_inputManager.SideMoveValue() > 0)
        {
            _spriteRenderer.flipX = false;
            _attackTrigger.localEulerAngles = new Vector3(0, 0, 0);
        }

        _animator.SetFloat("Speed", Mathf.Abs(_inputManager.SideMoveValue()));

        Vector3 direction = transform.position + Vector3.right * _inputManager.SideMoveValue();
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * _speed);
    }

    private void ActivateJump()
    {
        _animator.SetFloat("yAxis", _rb.velocity.y);

        if (checkYAxis && _rb.velocity.y == 0)
        {
            _animator.SetBool("Land", true);
        }
        else if(!checkYAxis)
        {
            _animator.SetBool("Land", false);
        }

        if (_grounded && _inputManager.JumpButtonWasClicked() && !playerIsJumping)
        {
            playerIsJumping = true;
            _animator.SetTrigger("Jump");
        }
    }

    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundChecker.position, _checkerRadius, _whatIsGround);

        if (colliders.Length > 0)
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }
    }

    public IEnumerator JumpCourutine()
    {
        _rb.AddForce(new Vector2(0f, _jumpForce));
        yield return new WaitForSeconds(0.5f);
        checkYAxis = true;
    }
}
