using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public float textSpeed;
    [TextArea(3, 9)] // creates more room to type out dialogue in the inspector
    public string[] sentences;
    public float[] pauseTimes;
    public int[] fontSizes;
}
