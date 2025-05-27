using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private ZombiePool zombiePool;
    [SerializeField] private Queue<GameObject> activeZombies = new Queue<GameObject>();

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

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S)) SpawnZombie();
        if (Input.GetKeyDown(KeyCode.D))
        {
            zombiePool.DeleteZombie(activeZombies.Dequeue());
        }
    }
}
