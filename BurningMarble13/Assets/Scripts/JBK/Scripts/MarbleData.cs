using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="MarbleData", menuName = "Data/Marble")]
public class MarbleData : ScriptableObject
{
    public int MarbleID;
    public string MarbleName;
    public Sprite MarbleImage;
    public string MarbleDescription;
}