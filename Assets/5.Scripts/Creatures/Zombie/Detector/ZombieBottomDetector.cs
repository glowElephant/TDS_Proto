using System;
using UnityEngine;

public class ZombieBottomDetector : MonoBehaviour
{
    [HideInInspector] public GameObject overlapObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Zombie"))
        {
            overlapObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Zombie"))
        {
            overlapObject = null;
        }
    }
}
