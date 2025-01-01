using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wiviart.Local
{
    public abstract class ALoader<T> : MonoBehaviour
    {
        protected T result;

        protected abstract void Load(AssetReference path);
        protected abstract void OnLoadCompleted();
        
        protected IEnumerator OnLoad(AssetReference url)
        {
            Debug.Log("Loading asset from " + url);

            var process = Addressables.LoadAssetAsync<T>(url);
            yield return process;

            if (process.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Asset loaded successfully " + process.Result);

                result = process.Result;
                OnLoadCompleted();

                Addressables.Release(result);
            }
            else
            {
                Debug.LogError($"Failed to load asset at {url}");
            }
        }
    }
}