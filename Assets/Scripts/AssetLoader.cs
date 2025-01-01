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

        ShowProgress(handle);

        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError("Failed to load asset");
            return default;
        }

        Debug.Log("Asset " + handle.Result + " Loaded");
        return handle.Result;
    }

    public static void LoadScene(AssetReference astRef)
    {
        var handle = Addressables.LoadSceneAsync(astRef);
        ShowProgress(handle);
        handle.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Failed)
                Debug.LogError("Failed to load scene");
            else
                Debug.Log("Scene " + handle.Result + " Loaded");
        };
    }

    private static async void ShowProgress(AsyncOperationHandle handle)
    {
        while (true)
        {
            var text = handle.PercentComplete * 100;
            StatusText.SetText("Loading... " + text.ToString("F2") + "%");
            await Task.Delay(100);

            if (handle.Status != AsyncOperationStatus.None)
                break;
        }
    }
}