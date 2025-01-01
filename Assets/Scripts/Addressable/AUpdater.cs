using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wiviart.Remote
{
    public abstract class AUpdater
    {
        public static int updateCount;

        public static IEnumerator CheckForUpdates()
        {
            // Step 1: Check for catalog updates
            var catalogUpdateHandle = Addressables.CheckForCatalogUpdates(false);
            yield return catalogUpdateHandle;

            if (catalogUpdateHandle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError("CheckForCatalogUpdates failed or returned an invalid handle.");
                yield break;
            }
            else
            {
                Debug.Log($"CheckForCatalogUpdates succeeded. Catalog updates found: {catalogUpdateHandle.Result.Count}");
            }

            if (catalogUpdateHandle.Result.Count <= 0) yield break;

            // Step 2: Update the catalog if necessary
            var updateHandle = Addressables.UpdateCatalogs(catalogUpdateHandle.Result, false);
            yield return updateHandle;

            if (updateHandle.Status != AsyncOperationStatus.Succeeded)
                Debug.LogError("Catalog update failed.");
            else
                Debug.Log("Catalog updated.");

            Addressables.Release(updateHandle);
            Addressables.Release(catalogUpdateHandle);
        }
    }
}