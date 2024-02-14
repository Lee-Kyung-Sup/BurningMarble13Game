using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIController : MonoBehaviour
{

    public void Inventory()
    {
        SceneManager.LoadScene("InventoryScene");
    }
}
