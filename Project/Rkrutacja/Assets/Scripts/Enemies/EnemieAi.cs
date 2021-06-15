using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemieAi : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float _speed;
    [Header("Patrol settings")]
    [SerializeField] private bool _patrolingFromEdgeToEdge;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groudCheckerRayDistance;

    private bool _isMovingRight;
    private Animator _animator;

    [HideInInspector] public bool hit;

    private void Awake()
    {
        hit = false;
        _isMovingRight = true;
        _animator = GetComponent<Animator>();

        if (_patrolingFromEdgeToEdge)
        {
            _animator.SetBool("Walk", true);
        }
    }

    private void Update()
    {
        if (_patrolingFromEdgeToEdge && !hit)
        {
            MoveFromEdgeToEdge();
        }
    }

    public void MoveFromEdgeToEdge()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundHit = Physics2D.Raycast(_groundChecker.position, Vector2.down, _groudCheckerRayDistance);
        if (groundHit.collider == false)
        {
            if (_isMovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                _isMovingRight = true;
            }
        }
    }
}
