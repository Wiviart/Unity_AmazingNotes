using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class OnStart_MenuLoader : MonoBehaviour
{
    [SerializeField] private AssetReference sceneRef;

    private void Start()
    {
        AssetLoader<Scene>.LoadScene(sceneRef);
    }
}