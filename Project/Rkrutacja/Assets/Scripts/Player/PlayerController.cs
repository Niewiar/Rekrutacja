using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement options values")]
    [SerializeField] [Range(1, 10)] private float _speed;

    private InputManager _inputManager;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 direction = transform.position + Vector3.right * _inputManager.SideMoveValue();
        transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * _speed);
    }
}
