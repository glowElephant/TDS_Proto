using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 좀비들을 풀링하여 재사용하는 풀 클래스
/// </summary>
public class ZombiePool : MonoBehaviour
{
    private readonly Stack<GameObject> zombiePool = new Stack<GameObject>();
    private Zombie[] preloadZombies;
    [SerializeField] private GameObject[] prefab;

    void Start()
    {
        preloadZombies = GetComponentsInChildren<Zombie>(true);

        foreach (var item in preloadZombies)
        {
            zombiePool.Push(item.gameObject);
        }
    }

    public GameObject CreateZombie(Transform position)
    {
        if (zombiePool.Count > 0)
        {
            var zombie = zombiePool.Pop();
            zombie.transform.SetParent(position);
            zombie.transform.position = position.position;
            zombie.gameObject.SetActive(true);
            return zombie.gameObject;
        }
        else
        {
            GameObject newZombie = Instantiate(prefab[Random.Range(0,prefab.Length)], position);
            newZombie.gameObject.SetActive(true);
            return newZombie;
        }
    }

    public void DeleteZombie(GameObject targetZombie)
    {
        zombiePool.Push(targetZombie);
        targetZombie.transform.SetParent(transform);
        targetZombie.gameObject.SetActive(false);
    }
}
