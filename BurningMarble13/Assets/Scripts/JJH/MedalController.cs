using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalController : MonoBehaviour
{
    public Image OneMedal;
    public Image TwoMedal;
    public Image ThreeMedal;

    public void OpenMedal()
    {
        if(GameManager.isFirstClear[0] == true)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else if (GameManager.isFirstClear[1] == true)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else if (GameManager.isFirstClear[2] == true)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
    }
}
