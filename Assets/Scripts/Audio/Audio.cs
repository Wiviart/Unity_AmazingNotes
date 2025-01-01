using System;
using System.Threading.Tasks;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace AmazingNotes.Audios
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AssetReference dataRef;
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

        public async Task<ClipData> Init()
        {
            var data = await AssetLoader<SoundData>.LoadAsset(dataRef);
            var clips = data.backgroundClips;
            var index = Random.Range(0, clips.Count);
            var clipDataRef = clips[index];
            var clipData = await AssetLoader<ClipData>.LoadAsset(clipDataRef);
            var clip = await AssetLoader<AudioClip>.LoadAsset(clipData.clipRef);
            clipData.clip = _source.clip = clip;
            _source.Play();

            return clipData;
        }
    }
}