using AmazingNotes.Game;

namespace AmazingNotes.Objects
{
    public class ManualFade : Fade
    {
        private void OnEnable()
        {
            Observer.OnClick += ChangeAlphaOnClick;
            SetAlpha(originalAlpha);
        }

        private void OnDisable()
        {
            Observer.OnClick -= ChangeAlphaOnClick;
        }

        private void ChangeAlphaOnClick(int score)
        {
            ChangeAlphaCoroutine();
        }
    }
}