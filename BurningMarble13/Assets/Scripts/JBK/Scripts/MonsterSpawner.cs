using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class MonsterSpawner : MonoBehaviour
{
    //MS.cs
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
        StopAllCoroutines();
        Invoke("SpawnStart", 3);
    }

    private void Update()
    {
        // Monster.cs에서 하트가 삭제될 때 KillMonster가 증가가 안되서 maxSpawnCount보다 작아짐
        // 그래서 다음 Wave로 안넘어가는 문제 발생
        if (GameManager.killMonster == maxSpawnCount
            || (WaveSystem.currentWave % 5 == 0 && killMonster > 0))
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
            GameObject randomMonsterPrefab = MonsterPrefabs[Random.Range(0, MonsterPrefabs.Length - 1)];
            if(WaveSystem.currentWave % 5 == 0)
                randomMonsterPrefab = MonsterPrefabs[MonsterPrefabs.Length-1];
            GameObject clone = Instantiate(randomMonsterPrefab);

            Monster monster = clone.GetComponent<Monster>();
            if (monster != null)
            {
                monster.mobType = MakeMobType();
                if (monster.mobType == MobType.Small)
                    monster.hp += (WaveSystem.plusHP * WaveSystem.currentWave);
                else if (monster.mobType == MobType.Big)
                    monster.hp += (WaveSystem.plusHP * WaveSystem.currentWave) + 300;
                else//Boss
                {  
                    currentSpawnCount = maxSpawnCount;
                    monster.hp = WaveSystem.currentWave * 400;
                    monster.isbose = true;
                    //스케일커지는거
                }

                monster.Setup(wayPoints);
                currentSpawnCount++;

                Debug.Log(monster.hp);
                Debug.Log(monster.mobType);
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private MobType MakeMobType()//난이도조절도가능//인피니티모드용 다시
    {
        if (WaveSystem.currentWave >= 2)
        {
            if (WaveSystem.currentWave % 5 == 0)
            {
                return MobType.Boss;
            }
            else
            {
                float temp = Random.Range(0, waveSystem.MaxWave + 5);
                if (temp == waveSystem.MaxWave)
                    return MobType.Big;
            }

        }
        return MobType.Small;
    }
}
