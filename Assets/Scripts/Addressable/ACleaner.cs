using UnityEngine;

public abstract class ACleaner : MonoBehaviour
{
    public static void CleanCache()
    {
        var cleared = Caching.ClearCache();

        Debug.Log(cleared ? "Cache cleaned" : "Cache is using, can not cleaned");
    }
}