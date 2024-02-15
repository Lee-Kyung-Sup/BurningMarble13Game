using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //GM.cs
    public static GameManager Instance;

    public static int choioceStageNum;

    private WaveSystem waveSystem;

    [SerializeField]
    private GameObject gameOverUI;//임시 GameOverUI
    [SerializeField]
    private GameObject gameClearUI;//GameClearUI 추가
    [SerializeField]
    private Image[] life;

    [HideInInspector]
    public int gold = 0;

    [HideInInspector]
    public static int killMonster;

    //gameover, pause menu
    public GameObject mainMenuBtn;
    public GameObject replayBtn;
    public GameObject pausemenuBtn;
    public GameObject pauseBtn;
    private bool isPaused = false;

    [HideInInspector]
    public static bool isReplay = false;
    [HideInInspector]
    public static int randomRoad;

    private static bool[] isFirstClear = new bool[3] { false, false , false };

    public enum MobType
    {
        Small = 0,
        Big,
        Boss,
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        waveSystem = GetComponent<WaveSystem>();

        //DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Time.timeScale = 1;
        waveSystem.StageChoice(choioceStageNum);
        gold = 200;
    }

    void Update()
    {

    }

    public void PauseMenuButton()
    {
        pausemenuBtn.SetActive(true);
    }

    //pause
    void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseBtn.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseBtn.SetActive(true);
        pausemenuBtn.SetActive(false);
    }

    /*
    강화 5단계
    업그레이드 비용
    1 > 2
    20프로 증가
    2 > 3
    40프로 증가
    3 > 4
    65프로 증가
    4 > 5
    100프로 증가
     
     */

    public void PlusGold(MobType type)
    {
        switch (type)
        {
            case MobType.Small:
                gold += 20;
                break;
            case MobType.Big:
                gold += 30;
                break;
            case MobType.Boss:
                gold += 50;
                break;
        }
    }


    public void GameOverUIOpen()//임시 GameOverUI
    {
        gameOverUI.SetActive(true);
    }

    public void GameEndMainMenuBtn() //임의로 작성된 명칭
    {
        StopAllCoroutines();
        SceneManager.LoadScene("MainMenu");
        isReplay = false;
        killMonster = 0;
    }

    public void GameEndReplayBtn()//임의로 작성된 명칭
    {
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isReplay = true;
        killMonster = 0;
    }
    public void Life(int count)
    {
        if (count >= life.Length)
            count = life.Length - 1;
        life[count].color = Color.black;
    }

    public void GameClearUIOpen() //GameOverUIOpen과 명칭을 통일시켜야 할 것 같아요
    {
        gameClearUI.SetActive(true);//2.15 11시37분에 받은 clearUI로 변경

        //보상주기용
        if (choioceStageNum == 1)
        {
            if (isFirstClear[0] == false)
            {
                //구슬2개
                isFirstClear[0] = true;
            }
        }
        else if (choioceStageNum == 2)
        {
            if (isFirstClear[1] == false)
            {
                //구슬2개
                isFirstClear[1] = true;
            }
        }
        else if (choioceStageNum == 3)
        {
            if (isFirstClear[2] == false)
            {
                //구슬3개
                isFirstClear[2] = true;
            }
        }

    }
}
