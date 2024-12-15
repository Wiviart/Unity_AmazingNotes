using UnityEngine;

public class InGameMenu_Button : UI_Button
{
    [SerializeField] private GameObject inGameMenu;

    protected override void OnClick()
    {
        inGameMenu.SetActive(!inGameMenu.activeSelf);
    }
}