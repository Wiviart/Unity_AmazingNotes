using UnityEngine;

namespace AmazingNotes.Audios
{
    [CreateAssetMenu(fileName = "ClipData", menuName = "Scriptable Objects/ClipData")]
    public class ClipData : ScriptableObject
    {
        public AudioClip clip;
        public int bpm;
    }
}