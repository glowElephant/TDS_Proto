using System;
using UnityEngine;

public class PistonDetector : MonoBehaviour
{
    public Action<Collider2D> OnCollisionDetected;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            OnCollisionDetected?.Invoke(collision);
        }
    }
}

