using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AmazingNotes.Audios
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Scriptable Objects/Sound Data", order = 1)]
    public class SoundData : ScriptableObject
    {
        public List<AssetReference> backgroundClips;
    }
}