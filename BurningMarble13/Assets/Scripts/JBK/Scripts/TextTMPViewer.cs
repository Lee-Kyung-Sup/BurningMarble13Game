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

    // Update is called once per frame
    void Update()
    {
        textWave.text = "Wave " + waveSystem.CurrentWaveIndex + " / " + waveSystem.MaxWave;
    }
}