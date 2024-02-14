using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textWave;
    [SerializeField]
    private TextMeshProUGUI textGold;

    [SerializeField]
    private WaveSystem waveSystem;

    void Update()
    {
        TextWave();
        TextGold();
    }

    private void TextWave()
    {
        //if문 사용
        // 인피니티모드를 선택하면 MaxWave가 ???로 변경(임시)
        // 인피니티 모드가 int의 최대값이라 100이상으로 설정(임시)
        if(waveSystem.MaxWave >= 100)
        {
            textWave.text = "WAVE " + (WaveSystem.currentWave) + " / ???";
        }
        else
        {
            textWave.text = "WAVE " + (WaveSystem.currentWave) + " / " + waveSystem.MaxWave;
        }
        
    }
    private void TextGold()
    {
        int gold = GameManager.Instance.gold;

        textGold.text = gold.ToString();
    }
}