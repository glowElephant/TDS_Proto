using UnityEngine;

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
