using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private int currentWaveIndex = -1;
    public int CurrentWaveIndex => currentWaveIndex + 1;
    public int MaxWave => waves.Length;

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct Wave
{
    
}
