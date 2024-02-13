using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int choioceStageNum;

    private WaveSystem waveSystem;

    [SerializeField]
    private GameObject gameOverUI;//임시 GameOverUI
    [SerializeField]
    private Image[] life;

    [HideInInspector]
    public long gold = 0;


    private void Awake()
    {
        Instance = this;
        waveSystem = GetComponent<WaveSystem>();
    }
    private void Start()
    {
        waveSystem.StageChoice(choioceStageNum);
    }

    void Update()
    {
        /*if(만약 몬스터의 체력이 0이 되었을 때)->이벤트 함수로 걸어두기?
        {
            PlusGold();
        }*/
    }

    /* public void PlusGold()
    {
         switch(몬스터 종류(타입))
            {
                case 소형:
                    gold += 10;
                    break;
                case 대형:
                    gold += 20;
                    break;
                case 보스:
                    gold += 30;
                    break;
            }   
    }*/

    public void GameOverUIOpen()//임시 GameOverUI
    {
        gameOverUI.SetActive(true);
    }

    public void Life(int count)
    {
        life[count].color = Color.black;
    }
}
