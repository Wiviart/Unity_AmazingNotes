using UnityEngine.SceneManagement;

public class Play_Button : UI_Button
{
    protected override void OnClick()
    {
        SceneManager.LoadSceneAsync(ConstTag.GameScene);
    }
}