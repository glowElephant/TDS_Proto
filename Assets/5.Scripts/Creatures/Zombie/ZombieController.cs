using UnityEngine;

/// <summary>
/// 좀비를 움직이게 하는 컨트롤러
/// </summary>
public class ZombieController : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    private float angleRad;
    private Vector2 leftUp;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        angleRad = 40f * Mathf.Deg2Rad;
        leftUp = new Vector2(-Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized; 
        // 앞으로 직진하는 것보다 왼쪽 위로 했을때 움직이기 수월하므로 leftUp 벡터를 설정
    }

    private void LimitAllDirections()
    {
        if (body.velocity.magnitude < maxSpeed)
        {
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
            // 간혹 힘을 너무 많이받아 튀어오르는 좀비가 생길 수 있으므로 속도를 제한
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(leftUp * moveSpeed, ForceMode2D.Force);
        LimitAllDirections();
    }
}


