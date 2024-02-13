using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

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
        if (GameManager.killMonster == maxSpawnCount)
        {
            waveSystem.NextWave();
            GameManager.killMonster = 0;
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
                monster.mobType = MakeMobType();
                monster.hp += (WaveSystem.plusHP * WaveSystem.currentWave);
                monster.Setup(wayPoints);
                currentSpawnCount++;

                Debug.Log(monster.hp);
                Debug.Log(monster.mobType);
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private MobType MakeMobType()//난이도조절도가능
    {
        if (WaveSystem.currentWave >= 2)
        {
            float temp = Random.Range(0, waveSystem.MaxWave + 6);
            if (temp >= waveSystem.MaxWave)
                return MobType.Big;
        }
        return MobType.Small;
    }
}
