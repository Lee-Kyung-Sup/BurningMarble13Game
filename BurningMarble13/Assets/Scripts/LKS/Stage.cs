using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public GameObject menuPlayStage;
    public GameObject selectStageOne;
    public GameObject selectStageTwo;
    public GameObject selectStageThree;
    public GameObject selectInfinityMode;
    // Start is called before the first frame update
    void Start()
    {
        menuPlayStage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageOne()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StageTwo()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void StageThree()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void InfinityMode()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Back()
    {
        menuPlayStage.SetActive(false);
    }
}
