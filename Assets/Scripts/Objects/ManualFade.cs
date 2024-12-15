using AmazingNotes.Game;

namespace AmazingNotes.Objects
{
    public class ManualFade : Fade
    {
        private void Start()
        {
            Observer.Instance.OnClick += ChangeAlphaOnClick;
            Observer.Instance.OnHold += ChangeAlphaOnClick;
            SetAlpha(originalAlpha);
        }

        private void OnDisable()
        {
            Observer.Instance.OnClick -= ChangeAlphaOnClick;
            Observer.Instance.OnHold -= ChangeAlphaOnClick;
        }

        private void ChangeAlphaOnClick(int score)
        {
            ChangeAlphaCoroutine();
        }
    }
}