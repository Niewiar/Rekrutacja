﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudChecker : MonoBehaviour
{
    [HideInInspector] public bool grounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
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
