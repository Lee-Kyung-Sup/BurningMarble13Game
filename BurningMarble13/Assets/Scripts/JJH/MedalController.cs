using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalController : MonoBehaviour
{
    public Image OneMedal;
    public Image TwoMedal;
    public Image ThreeMedal;

    private void Start()
    {
        OneMedal.enabled = false;
        TwoMedal.enabled = false;
        ThreeMedal.enabled = false;
    }

    public void OpenMedal()
    {
        if(GameManager.isFirstClear[0] == true)
        {
            OneMedal.enabled = true;
        }
        if (GameManager.isFirstClear[1] == true)
        {
            TwoMedal.enabled = true;
        }
        if (GameManager.isFirstClear[2] == true)
        {
            ThreeMedal.enabled = true;
        }
    }
}
