using UnityEngine;

/// <summary>
/// 좀비 밑바닥에 있는 콜라이더로 좀비가 바닥에 붙어있는지 탐지
/// </summary>
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
