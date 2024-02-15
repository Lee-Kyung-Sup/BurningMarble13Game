using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public GameObject menuPlayStage;
    public GameObject selectStageOne;
    public GameObject selectStageTwo;
    public GameObject selectStageThree;
    public GameObject selectInfinityMode;

    private bool clearCheck;

    void Start()
    {
        menuPlayStage.SetActive(true);
    }

    public void ModeChoice(int mode)
    {
        if (clearCheck = GameManager.isFirstClear.All(x => x == true))
        {
            switch (mode)
            {
                case 1:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                case 2:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                case 3:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                case 4://인피니티모드 //이거 사용
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                default:
                    return;
            }
        }
        else
        {
            switch (mode)
            {
                case 1:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                case 2:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                case 3:
                    SceneManager.LoadScene("GameScene");
                    GameManager.choioceStageNum = mode;
                    break;
                default:
                    return;
            }
        }
    }

    // 인피니티 버튼에서 잠시 해제
    // 위 인피니티 모드 적용중(임시)
    public void InfinityMode()//나중에 무한모드 구현후삭제
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Back()
    {
        menuPlayStage.SetActive(false);
    }
}
