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

    public enum MobType
    {
        Small = 0,
        Big,
        Boss,
    }

    private void Awake()
    {
        Instance = this;
        waveSystem = GetComponent<WaveSystem>();
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

    public void GameOverUIMainMenuBtn()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("MainMenu");
        isReplay = false;
        killMonster = 0;
    }

    public void GameOverUIReplayBtn()
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

    public void GameClearUI()
    {
        gameOverUI.SetActive(true);//임시로 게임오버UI 올리기
        //Medal();
    }
}
