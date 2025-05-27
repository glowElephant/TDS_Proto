using UnityEngine;

/// <summary>
/// 총을 제어하는 클래스, 마우스 방향 바라보기, 발사 등 기능 구현
/// </summary>
public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;

    private void FixedUpdate()
    {
        AimMouse();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void AimMouse()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            body.velocity = firePoint.right * bulletSpeed;
        }
    }
}
