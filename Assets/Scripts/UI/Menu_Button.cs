using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace AmazingNotes.UI
{
    public class Menu_Button : UI_Button
    {
        [SerializeField] private AssetReference sceneRef;

        protected override void OnClick()
        {
            AssetLoader<Scene>.LoadScene(sceneRef);
        }
    }
}