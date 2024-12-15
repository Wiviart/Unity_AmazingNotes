using AmazingNotes.Game;
using UnityEngine.SceneManagement;

namespace AmazingNotes.UI
{
    public class Menu_Button : UI_Button
    {
        protected override void OnClick()
        {
            SceneManager.LoadSceneAsync(ConstTag.MenuScene);
        }
    }
}