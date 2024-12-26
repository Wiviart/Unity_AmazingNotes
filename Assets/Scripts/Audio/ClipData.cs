using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AmazingNotes.Audios
{
    [CreateAssetMenu(fileName = "ClipData", menuName = "Scriptable Objects/ClipData")]
    public class ClipData : ScriptableObject
    {
        public AssetReference clipRef;
        public AudioClip clip;
        public int beatsPerMinute;
    }
}