using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform MenuIcon;
    [SerializeField] private GameObject sideBar;

    bool IsOpen = false;

    private void Start()
    {
        Time.timeScale = 1.0f;
        // SlotManager.Instance.;
    }

    public void OnClickMenu()
    {
        if (IsOpen == false)
        {
            sideBar.transform.DOLocalMoveX(800, 1.0f).SetEase(Ease.OutQuad);
            IsOpen = true;
            Debug.Log("����");
        }
        else if (IsOpen == true)
        {
            sideBar.transform.DOLocalMoveX(1200, 1.0f).SetEase(Ease.OutBounce);
            IsOpen = false;
            Debug.Log("����");
        }
    }
    public void Inventory()
    {
        SceneManager.LoadScene("InventoryScene");
    }
}
