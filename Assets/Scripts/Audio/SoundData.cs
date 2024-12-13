using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "Scriptable Objects/Sound Data", order = 1)]
public class SoundData : ScriptableObject
{
    public List<AudioClip> backgroundClips = new List<AudioClip>();
}