using System;
using UnityEngine;

public class ZombieFrontDetector : MonoBehaviour
{
    public Collider2D frontCollider;
    public Action<Collider2D> OnCollisionDetected;

    private void Awake()
    {
        if (frontCollider == null)
        {
            frontCollider = GetComponent<Collider2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            OnCollisionDetected?.Invoke(collision);
        }
    }
}
