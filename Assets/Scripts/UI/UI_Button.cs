using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.UI
{
    public abstract class UI_Button : MonoBehaviour
    {
        protected Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}