using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform Menu;
    [SerializeField] private GameObject background;

    public void OnClickMenu()
    {
        background.transform.DOLocalMoveX(800, 1.0f).SetEase(Ease.OutQuad);
    }

    public void OnClickClose()
    {
        background.transform.DOLocalMoveX(1200, 1.0f).SetEase(Ease.OutBounce);
    }


    public void Inventory()
    {
        SceneManager.LoadScene("InventoryScene");
    }
}
