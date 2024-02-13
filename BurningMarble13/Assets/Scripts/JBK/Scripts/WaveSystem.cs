using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [HideInInspector]
    public int MaxWave = 0;

    [HideInInspector]
    public int currentWave = 1;//텍스트로 나올때 +1하기위해
    //public int CurrentWaveIndex => currentWaveIndex + 1;//현재웨이브//읽기전용

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

        if (MaxWave < currentWave)//스테이지종료
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
            default:
                return;
        }

    }

    public void SetStage(int maxWave)
    {
        button.SetActive(false);//게임씬 작업용 나중에 삭제

        MaxWave = maxWave;
        //웨이브당 체력증가수치 1=10 2=15 3=20
        //몬스터수

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