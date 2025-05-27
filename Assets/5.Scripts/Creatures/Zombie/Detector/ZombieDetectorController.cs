using System;
using UnityEngine;

/// <summary>
/// 좀비의 앞, 아래, 뒤를 탐지하여 앞에있는 좀비를 타고 오를 수 있도록 제어하는 컨트롤러
/// </summary>
public class ZombieDetectorController : MonoBehaviour
{
    [SerializeField] private ZombieFrontDetector frontDetector;
    [SerializeField] private ZombieBottomDetector bottomDetector;
    [SerializeField] private ZombieBackDetector backDetector;
    [SerializeField] private float climbForce = 4.7f;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float climbEnableTime = 0.5f;
    private float climbEnableTimer;

    void OnEnable()
    {
        frontDetector.OnCollisionDetected += HandleFrontCollision;
    }

    void OnDisable()
    {
        frontDetector.OnCollisionDetected -= HandleFrontCollision;
    }

    private void HandleFrontCollision(Collider2D zombieCollider)
    {
        Climb();
    }

    public Zombie DetectChainZombie()
    {
        return backDetector.CheckOverlap();
    }

    private void FixedUpdate()
    {
        if (climbEnableTimer <= climbEnableTime)
        {
            climbEnableTimer += Time.fixedDeltaTime;
        }
        
    }

    public void Climb()
    {
        if (bottomDetector.overlapObject != null && climbEnableTimer >= climbEnableTime)
        {
            var backZombie = backDetector.CheckOverlap();
            if (backZombie == null)
            {
                body.AddForce(Vector3.up * climbForce, ForceMode2D.Impulse);
                climbEnableTimer = 0f;
            }
            else
            {
                backZombie.detectorController.Climb();
            }
        }
    }
}
