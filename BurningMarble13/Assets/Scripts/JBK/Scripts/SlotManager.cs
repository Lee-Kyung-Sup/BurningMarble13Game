using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[System.Serializable]
public class MarbleInfo
{
    public bool IsEquipped;
    public MarbleData MarbleData;
}

public class SlotManager : MonoBehaviour
{
    public static SlotManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public List<MarbleInfo> Inventory = new List<MarbleInfo>();


    //public void MarbleValues()
    //{
    //    for (int i = 0; i < marbles.Length; i++)
    //    {
    //        marbles[i] = i;
    //    }
    //}

    //private void Start()
    //{
    //    MarbleValues();
    //}
}
