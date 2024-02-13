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

    [HideInInspector]   
    public int maxSpawnCount = 20;

    private int currentSpawnCount = 0;

    private void Start()
    {
        Invoke("SpawnStart", 3);
    }

    public void SpawnStart()
    {
        StartCoroutine("SpawnMonster");
    }

    private IEnumerator SpawnMonster()
    {
        //수정
        if (currentSpawnCount == maxSpawnCount )
        {
            StopCoroutine("SpawnMonster");
            currentSpawnCount = 0;
        }
        //

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
