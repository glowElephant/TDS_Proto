using UnityEngine;

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
    }

    private void LimitAllDirections()
    {
        if (body.velocity.magnitude < maxSpeed)
        {
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(leftUp * moveSpeed, ForceMode2D.Force);
        LimitAllDirections();
    }
}


