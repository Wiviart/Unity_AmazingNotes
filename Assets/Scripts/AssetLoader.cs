using System.Threading.Tasks;
using AmazingNotes.Audios;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class AssetLoader<T>
{
    public static async Task<T> LoadAsset(AssetReference astRef)
    {
        var handle = Addressables.LoadAssetAsync<T>(astRef);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("Failed to load asset");
            return default;
        }

        Debug.Log("Loaded");
        return handle.Result;
    }

    public static void LoadScene(AssetReference astRef)
    {
        Addressables.LoadSceneAsync(astRef);
    }
}