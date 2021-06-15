using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCombat : MonoBehaviour
{
    [Header("Repulse target")]
    [SerializeField] private bool _canRepulseTarget;
    [SerializeField] private float _horizontalRepulseForce = 100f;
    [SerializeField] private float _verticalRepulseForce = 500f;
    [SerializeField] private float _timeToUnlockTargetMovement = 0.7f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RepulseTarget(collision.gameObject);
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
}
