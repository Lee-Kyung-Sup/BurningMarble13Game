using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MonsterPrefabs;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private int maxSpawnCount = 20;

    private int currentSpawnCount = 0;
    private void Awake()
    {
        StartCoroutine("SpawnMonster");
    }

    private IEnumerator SpawnMonster()
    {
        while (currentSpawnCount < maxSpawnCount)
        {
            GameObject randomMonsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Length)];
            GameObject clone = Instantiate(randomMonsterPrefab);

            Monster monster = clone.GetComponent<Monster>();
            if (monster != null)
            {
                monster.Setup(wayPoints);
                currentSpawnCount++;
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
