using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [HideInInspector]
    public int MaxWave = 0;

    [HideInInspector]
    public static int currentWave = 1;//텍스트로 나올때 +1하기위해
    //public int CurrentWaveIndex => currentWaveIndex + 1;//현재웨이브//읽기전용

    [HideInInspector]
    public static int plusHP = 0;

    [SerializeField]
    public GameObject[] Road;

    public GameObject button;//임시

    private MonsterSpawner monsterSpawner;


    void Update()
    {
        // maxSpawnCount == currenSpawnCount
        // 웨이브가 1증가 
        // 맥스웨이브 == 현재웨이브 ->게임승리-> wavesystem
        // 목숨이 3개 사라지면 게임오버-> monster에 구현
        //

        if (MaxWave == currentWave )//스테이지종료
        {
            //WIN UI OPEN-> Main으로 돌아가기, 다시하기
        }
    }


    public void StageChoice(int stage)
    {
        switch (stage)
        {
            case 1:
                SetStage(10);
                break;
            case 2:
                SetStage(15);
                break;
            case 3:
                SetStage(20);
                break;
            case 4:
                InfinityStage();
                break;
            default:
                return;
        }

    }

    public void SetStage(int maxWave)
    {
        button.SetActive(false);//게임씬 작업용 나중에 삭제

        MaxWave = maxWave;
        plusHP = maxWave;
        //웨이브당 체력증가수치 1=10 2=15 3=20
        //몬스터수

        int random = Random.Range(0, Road.Length);
        Debug.Log(random + "번 Road");

        Road[random].SetActive(true);
        monsterSpawner = Road[random].GetComponent<MonsterSpawner>();
    }

    public void InfinityStage()
    {
        button.SetActive(false);//게임씬 작업용 나중에 삭제

        MaxWave = 2147483647; //int의 최대값을 적용함

        // 만약 현재 Wave가 1이상 10이하면 hp = 10, 11~20이면 15, 그 이상이면 20으로 통일(임시)
        if (currentWave >= 1 || currentWave <= 10)
        {
            plusHP = 10;
        }
        else if (currentWave >= 11 || currentWave <= 20)
        {
            plusHP = 15;
        }
        else
        {
            plusHP = 20;
        }


        int random = Random.Range(0, Road.Length);
        Debug.Log(random + "번 Road");

        Road[random].SetActive(true);
        monsterSpawner = Road[random].GetComponent<MonsterSpawner>();
    }

    public void NextWave()
    {
        currentWave++;
    }


}