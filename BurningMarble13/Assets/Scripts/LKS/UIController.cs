using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //public GameObject mainMenu;
    public GameObject inventoryBtn;
    public GameObject playBtn;
    public GameObject menuPlay;

    void Start()
    {
        //mainMenu.SetActive(true);
        inventoryBtn.SetActive(true);
        playBtn.SetActive(true);
        menuPlay.SetActive(false);
    }

    public void Inventory()
    {
        SceneManager.LoadScene("InventoryScene");
    }

    public void Play()
    {
        menuPlay.SetActive(true);
    }

    
}
