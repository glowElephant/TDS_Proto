using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PistonCollider : MonoBehaviour
{
    [SerializeField] private float pistonSpeed = 2f;
    [SerializeField] private float pistonDuration = 0.7f;
    [SerializeField] private float pistonDelay = 1f;

    private Transform targetZombie;
    private Coroutine pistonCoroutine;

    public bool IsActivated { get; private set; } = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            targetZombie = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            targetZombie = null;
        }
    }

    public void ActivatePiston()
    {
        if (pistonCoroutine != null)
        {
            StopCoroutine(pistonCoroutine);
        }
        if (targetZombie != null)
        {
            pistonCoroutine = StartCoroutine(ActivePistonRoutine());
        }
    }

    private IEnumerator ActivePistonRoutine()
    {
        IsActivated = true;

        // 연쇄적으로 연결된 좀비 리스트 가져오기
        List<Transform> chainZombies = GetChainZombie();
        if (chainZombies == null || chainZombies.Count == 0)
        {
            // 대상이 없으면 바로 종료
            yield return new WaitForSeconds(pistonDelay);
            IsActivated = false;
            yield break;
        }

        // Rigidbody2D 컴포넌트 모으기
        var bodys = chainZombies
            .Select(z => z.GetComponent<Rigidbody2D>())
            .Where(rb => rb != null)
            .ToList();

        float elapsed = 0f;
        // pistonDuration 시간만큼 매 프레임 등속도 설정
        while (elapsed < pistonDuration)
        {
            for (int i = 0; i < bodys.Count; i++)
            {
                if (i == 0)
                {
                    bodys[i].velocity = Vector2.right * pistonSpeed;
                }
                else
                {
                    bodys[i].velocity = Vector2.right * (pistonSpeed + Random.Range(0.3f, 0.5f));
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }


        yield return new WaitForSeconds(pistonDelay);
        IsActivated = false;
    }
    int count = 0;
    private List<Transform> GetChainZombie()
    {
        if (targetZombie == null)
        {
            return null;
        }

        List<Transform> chainZombies = new List<Transform>();

        var zombie = targetZombie.GetComponent<Zombie>();
        count++;
        while (zombie != null)
        {
            zombie.name = count.ToString();
            chainZombies.Add(zombie.transform);
            zombie = zombie.detectorController.DetectChainZombie();
        }

        return chainZombies;
    }
}
