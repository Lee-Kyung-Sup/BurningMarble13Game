using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Opening : MonoBehaviour
{
    public GameObject startScreenUI;
    //public GameObject mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        startScreenUI.SetActive(true); //나중에 true로 바꾸기
        //mainMenuUI.SetActive(false); //나중에 false로 바꾸기
    }

    
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
        //startScreenUI.SetActive(false);
        //mainMenuUI.SetActive(true);
    }
}

