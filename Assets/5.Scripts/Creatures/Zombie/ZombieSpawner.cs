using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 좀비를 생성하고 관리하는 스포너 클래스
/// </summary>
public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private ZombiePool zombiePool;
    [SerializeField] private Queue<GameObject> activeZombies = new Queue<GameObject>();

    private void Start()
    {
        StartCoroutine(AutoSpawnZombie());
    }

    private void SpawnZombie()
    {
        int spawnIndex = Random.Range(0, spawnPositions.Length);
        var zombie = zombiePool.CreateZombie(spawnPositions[spawnIndex]);
        var colliders = zombie.GetComponentsInChildren<Collider2D>(true);
        var sprites = zombie.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var item in colliders)
        {
            item.gameObject.layer = LayerMask.NameToLayer($"ZombiePos{spawnIndex + 1}");
        }

        foreach (var item in sprites)
        {
            item.sortingLayerName = $"ZombiePos{spawnIndex + 1}";
        }
        activeZombies.Enqueue(zombie);
    }

    private IEnumerator AutoSpawnZombie()
    {
        while (true)
        {
            SpawnZombie();
            yield return new WaitForSeconds(1.5f); // 1초마다 좀비 생성
        }
    }
}
