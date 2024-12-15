using System;
using AmazingNotes.Game;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AmazingNotes.Audios
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private SoundData data;
        [SerializeField] private AudioClip endClip;

        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Observer.Instance.OnGameEnd += StopMusic;
        }

        private void OnDisable()
        {
            Observer.Instance.OnGameEnd -= StopMusic;
        }

        private void StopMusic()
        {
            _source.Stop();
            _source.clip = endClip;
            _source.Play();
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