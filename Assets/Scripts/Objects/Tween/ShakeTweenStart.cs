namespace AmazingNotes.Objects
{
    public class ShakeTweenStart : ShakeTween
    {
        void Start()
        {
            Invoke(nameof(StartChange), 0.1f);
        }
    }
}