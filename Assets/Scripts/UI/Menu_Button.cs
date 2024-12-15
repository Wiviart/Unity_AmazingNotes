using UnityEngine.SceneManagement;

public class Menu_Button : UI_Button
{
    protected override void OnClick()
    {
        SceneManager.LoadSceneAsync(ConstTag.MenuScene);
    }
}