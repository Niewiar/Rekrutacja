using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIncicator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GetComponentInParent<OverPoint>().DesactiveJumpIndicators();
            collision.GetComponent<EnemieAi>().Jump();
        }
    }
}
