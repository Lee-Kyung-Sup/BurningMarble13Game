using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [HideInInspector]
    public int MaxWave = 10;

    [HideInInspector]
    public static int currentWave = 1;//텍스트로 나올때 +1하기위해
    [HideInInspector]
    public int currentWaveText = 1;
    //public int CurrentWaveIndex => currentWaveIndex + 1;//현재웨이브//읽기전용

    [HideInInspector]
    public static int plusHP = 0;

    [SerializeField]
    public GameObject[] Road;

    public GameObject button;//임시


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
            Debug.Log("StageClear");
            StopAllCoroutines();
            Time.timeScale = 0;
            GameManager.Instance.GameClearUIOpen(); //GameClearUI함수 명 변경
            currentWave = 1;
        }

        if(GameManager.choioceStageNum == 4 && currentWave % 5 == 0)//준비중
        {
            plusHP += 5;
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
        currentWave = 9;
        currentWaveText = currentWave;

        button.SetActive(false);//게임씬 작업용 나중에 삭제

        MaxWave = maxWave;
        plusHP = maxWave;
        //웨이브당 체력증가수치 1=10 2=15 3=20
        //몬스터수->나중에 테스트후

        foreach(GameObject road in Road)
        {
            road.SetActive(false);
        }

        if (GameManager.isReplay == false)
        {
            GameManager.randomRoad = Random.Range(0, Road.Length);
            Debug.Log(GameManager.randomRoad + "번 Road");

            Road[GameManager.randomRoad].SetActive(true);
        }
        else
        {
            Road[GameManager.randomRoad].SetActive(true);
        }

    }

    public void InfinityStage()
    {
        button.SetActive(false);//게임씬 작업용 나중에 삭제

        currentWave = 1;
        currentWaveText = currentWave;

        MaxWave = int.MaxValue; //int의 최대값을 적용함

        plusHP = 10; // 기본 체력

        if (GameManager.isReplay == false)
        {
            int random = Random.Range(0, Road.Length);
            Debug.Log(random + "번 Road");

            Road[random].SetActive(true);
        }
        else
        {
            Road[GameManager.randomRoad].SetActive(true);
        }
    }

    public void NextWave()
    {
        currentWave++;
        if (currentWave > MaxWave)
            currentWaveText = MaxWave;
        else
            currentWaveText = currentWave;
    }


}