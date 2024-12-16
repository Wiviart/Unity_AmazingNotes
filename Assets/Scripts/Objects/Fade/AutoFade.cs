namespace AmazingNotes.Objects
{
    public class AutoFade : Fade
    {
        private void Start()
        {
            InvokeRepeating(nameof(ChangeAlphaCoroutine), 0, 1f);
        }
    }
}