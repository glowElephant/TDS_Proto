using System;
using UnityEngine;

/// <summary>
/// 좀비 앞쪽에 붙어있는 콜라이더를 통해 앞쪽에 좀비가 있는지 탐지
/// </summary>
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
