using UnityEngine;

public class PistonController : MonoBehaviour
{
    [SerializeField] PistonCollider pistonCollider;
    [SerializeField] PistonDetector pistonDetector;

    private void OnEnable()
    {
        pistonDetector.OnCollisionDetected += HandlePistonDetectorCollision;
    }

    private void OnDisable()
    {
        pistonDetector.OnCollisionDetected -= HandlePistonDetectorCollision;
    }

    private void HandlePistonDetectorCollision(Collider2D zombieCollider)
    {
        if (!pistonCollider.IsActivated)
        {
            pistonCollider.ActivatePiston();
        }
    }
}
