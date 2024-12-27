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
            var clips = AssetLoader.Instance.clipDatas;
            var index = Random.Range(0, clips.Length);
            var clipData = clips[index];
            _source.clip = clipData.clip;
            _source.Play();

            return clipData;
        }
    }
}