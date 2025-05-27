using UnityEngine;

/// <summary>
/// 좀비 뒤쪽에 붙어있는 콜라이더를 통해 뒤쪽에 좀비가 있는지 탐지
/// </summary>
public class ZombieBackDetector : MonoBehaviour
{
    private Zombie overlappingZombie;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            var zombie = other.GetComponent<Zombie>();
            if (zombie != null)
                overlappingZombie = zombie;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            var zombie = other.GetComponent<Zombie>();
            if (zombie != null)
                overlappingZombie = null;
        }
    }

    public Zombie CheckOverlap()
    {
        return overlappingZombie;
    }
}
