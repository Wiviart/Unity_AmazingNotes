using AmazingNotes.Game;
using UnityEngine;

namespace AmazingNotes.UI
{
    public class InGameMenu_Button : UI_Button
    {
        [SerializeField] private GameObject inGameMenu;

        private void Start()
        {
            Observer.Instance.OnGameEnd += GameEnd;
        }

        private void OnDisable()
        {
            Observer.Instance.OnGameEnd -= GameEnd;
        }

        protected override void OnClick()
        {
            inGameMenu.SetActive(!inGameMenu.activeSelf);
        }

        private void GameEnd()
        {
            inGameMenu.SetActive(true);
            button.interactable = false;
        }
    }
}