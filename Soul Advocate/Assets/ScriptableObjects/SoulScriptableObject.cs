using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new soul", menuName = "Scriptable Objects/Soul")]
public class SoulScriptableObject : ScriptableObject
{
    public string color;
    public string description;
    public Sprite[] sprites;
    //public soundFX
}
