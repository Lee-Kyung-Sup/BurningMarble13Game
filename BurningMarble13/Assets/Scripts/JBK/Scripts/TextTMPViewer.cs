using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textWave;
    [SerializeField]
    private WaveSystem waveSystem;

    void Update()
    {
        textWave.text = "Wave " + (waveSystem.currentWave) + " / " + waveSystem.MaxWave;
    }
}