using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Button : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}