using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wiviart.Remote
{
    public abstract class ADownloader
    {
        public static IEnumerator DownloadNewUpdate(AssetReference url)
        {
            Debug.Log("Downloading new update...");
            
            var downloadHandle = Addressables.DownloadDependenciesAsync(url);
            yield return downloadHandle;

            if (downloadHandle.Status != AsyncOperationStatus.Succeeded)
                Debug.LogError("Failed to download dependencies.");
            else
                Debug.Log("Dependencies downloaded.");

            Addressables.Release(downloadHandle);
        }
    }
}