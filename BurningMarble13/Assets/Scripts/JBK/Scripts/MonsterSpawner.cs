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
    public int maxSpawnCount = 10;

    private int currentSpawnCount = 0;

    private WaveSystem waveSystem;

    private void Start()
    {        
        waveSystem = GameManager.Instance.GetComponent<WaveSystem>();
        Invoke("SpawnStart", 3);
    }

    private void Update()
    {
        if (Monster.killMonster == maxSpawnCount)
        {
            waveSystem.NextWave();
            Monster.killMonster = 0;
            StopAllCoroutines();
            Invoke("SpawnStart", 3);
        }
    }

    public void SpawnStart()
    {
        currentSpawnCount = 0;
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
