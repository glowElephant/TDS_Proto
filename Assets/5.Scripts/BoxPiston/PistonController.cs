using UnityEngine;

/// <summary>
/// 1층 좀비를 전부 밀어내는 기능
/// </summary>
public class PistonController : MonoBehaviour
{
    /// <summary>
    /// PistonCollider는 좀비를 밀어내는 기능을 담당
    /// </summary>
    [SerializeField] PistonCollider pistonCollider;

    /// <summary>
    /// 2층 박스에 좀비가 닿았는지 탐지하는 기능 담당
    /// </summary>
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
