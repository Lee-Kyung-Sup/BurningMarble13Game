using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 생성할 몬스터 프리팹 배열
    public Transform[] spawnPoints; // 몬스터 스폰 위치 배열

    void Start()
    {
        // 몬스터 생성
        SpawnMonster();
    }

    void SpawnMonster()
    {
        // 무작위로 몬스터 프리팹 선택
        GameObject selectedMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

        // 무작위로 스폰 위치 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 몬스터 생성
        Instantiate(selectedMonsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
