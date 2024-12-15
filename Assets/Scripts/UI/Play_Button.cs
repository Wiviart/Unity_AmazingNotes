using AmazingNotes.Game;
using UnityEngine.SceneManagement;

namespace AmazingNotes.UI
{
    public class Play_Button : UI_Button
    {
        protected override void OnClick()
        {
            SceneManager.LoadSceneAsync(ConstTag.GameScene);
        }
    }
}