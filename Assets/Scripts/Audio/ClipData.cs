using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClipData", menuName = "Scriptable Objects/ClipData")]
public class ClipData : ScriptableObject
{
    public AudioClip clip;
    public int bpm;
}