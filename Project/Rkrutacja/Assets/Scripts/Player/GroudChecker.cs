using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudChecker : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    [HideInInspector] public bool grounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            _playerAnimator.SetTrigger("Land");
            Debug.Log("sasas");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
