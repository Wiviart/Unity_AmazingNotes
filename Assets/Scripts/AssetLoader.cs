using AmazingNotes.Audios;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetLoader : Singleton<AssetLoader>
{
    [SerializeField] private SoundData soundData;
    internal ClipData[] clipDatas;

    private void Start()
    {
        Debug.Log("Start loading assets");
        clipDatas = soundData.backgroundClips.ToArray();
        foreach (var clipData in clipDatas)
        {
            Addressables.LoadAssetAsync<AudioClip>(clipData.clipRef).Completed +=
                handle =>
                {
                    clipData.clip = handle.Result;
                    print("Loaded");
                };
        }

        Debug.Log("Finish loading assets");
    }
}