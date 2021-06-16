using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { Patrol, Atack }

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemieAi : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 390f;
    [Header("Attack")]
    [SerializeField] private bool _canAtack;
    [SerializeField] private float _atackRayDistance = 1f;
    [Header("Patrols type")]
    [SerializeField] [Tooltip("If true remember to set patrol settings")] private bool _patrolingFromEdgeToEdge;
    [SerializeField] [Tooltip("If true remember to set patrol settings")] private bool _standingPatrol;
    [SerializeField] [Tooltip("If true remember to set patrol settings")] private bool _patrolFromPointToPoint;
    [Header("Patrol edge to edge settings")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groudCheckerRayDistance = 0.4f;
    [Header("Standing patrol settings")]
    [SerializeField] private float _rotationTime = 2f;
    [Header("Patrol from point to point settings")]
    [SerializeField] [Tooltip("Set min 2 points. If you want to enemy jump you must set OverPoint")] private Transform[] _points;
    [SerializeField] private float _maxYVelocytyToContionueMoveAfterJump = 3.5f;
    [SerializeField] [Tooltip("Set over 0")] private float _minYVelocytyToContionueMoveAfterJump = 0.1f;

    private bool _isLookingRight;
    private Animator _animator;
    private Transform _currentPoint;
    private int _pointsIndex;
    private Rigidbody2D _rb;
    private bool _isJumping;
    private EnemyStates _enemyState;

    [HideInInspector] public bool hit;

    private void Awake()
    {
        _enemyState = EnemyStates.Patrol;
        _pointsIndex = 0;
        hit = false;
        _isLookingRight = true;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        if (_patrolingFromEdgeToEdge || _patrolFromPointToPoint)
        {
            _animator.SetBool("Walk", true);

            if (_patrolFromPointToPoint)
            {
                _currentPoint = _points[0];

                if (_currentPoint.GetComponent<OverPoint>())
                {
                    _currentPoint.GetComponent<OverPoint>().ActivateJumpIndicators();
                }
            }
        }
        else if (_standingPatrol)
        {
            StartCoroutine(StandingRotateCourutine());
        }
    }

    private void Update()
    {
        ChangeStates();

        if (_enemyState == EnemyStates.Patrol)
        {
            if (_patrolingFromEdgeToEdge && !hit)
            {
                MoveFromEdgeToEdge();
            }
            else if (_patrolFromPointToPoint && !hit)
            {
                MoveFromPointToPoint();
            }
        }
    }

    private void MoveFromEdgeToEdge()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundHit = Physics2D.Raycast(_groundChecker.position, Vector2.down, _groudCheckerRayDistance);
        if (groundHit.collider == false)
        {
            if (_isLookingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _isLookingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _isLookingRight = true;
            }
        }
    }

    private IEnumerator StandingRotateCourutine()
    {
        while (_standingPatrol)
        {
            if (_isLookingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _isLookingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _isLookingRight = true;
            }
            yield return new WaitForSeconds(_rotationTime);
        }
    }

    private void MoveFromPointToPoint()
    {
        Vector2 destiny = new Vector2(_currentPoint.position.x, transform.position.y);
        Vector2 direction = transform.position - _currentPoint.position;
        direction = direction.normalized;

        if (_isJumping && _rb.velocity.y < _maxYVelocytyToContionueMoveAfterJump && _rb.velocity.y > _minYVelocytyToContionueMoveAfterJump)
        {
            _isJumping = false;
        }

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if ((Vector2)transform.position != destiny && !_isJumping)
        {
            transform.position = Vector2.MoveTowards(transform.position, destiny, Time.deltaTime * _speed);
        }
        else if (!_isJumping)
        {
            if (_pointsIndex + 1 > _points.Length - 1)
            {
                _pointsIndex = 0;
            }
            else
            {
                _pointsIndex++;
            }

            _currentPoint = _points[_pointsIndex];

            if (_currentPoint.GetComponent<OverPoint>())
            {
                _currentPoint.GetComponent<OverPoint>().ActivateJumpIndicators();
            }
        }
    }

    private void ChangeStates()
    {
        RaycastHit2D targetHit = Physics2D.Raycast(transform.position, Vector2.right, _atackRayDistance);
        if (targetHit.collider.tag == "Player" && _canAtack)
        {
            _enemyState = EnemyStates.Atack;
        }
        else
        {
            _enemyState = EnemyStates.Patrol;
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
        _isJumping = true;
    }
}
