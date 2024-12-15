using UnityEngine;

namespace AmazingNotes.Audios
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private SoundData data;

        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public ClipData Init()
        {
            int random = Random.Range(0, data.backgroundClips.Count);
            _source.clip = data.backgroundClips[random].clip;
            _source.Play();

            return data.backgroundClips[random];
        }
    }
}