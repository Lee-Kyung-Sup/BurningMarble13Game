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
        textWave.text = "WAVE " + (WaveSystem.currentWave) + " / " + waveSystem.MaxWave;
    }
    private void TextGold()
    {
        int gold = GameManager.Instance.gold;

        textGold.text = gold.ToString();
    }
}