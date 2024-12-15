using UnityEngine;

namespace AmazingNotes.UI
{
    public class InGameMenu_Button : UI_Button
    {
        [SerializeField] private GameObject inGameMenu;

        protected override void OnClick()
        {
            inGameMenu.SetActive(!inGameMenu.activeSelf);
        }
    }
}