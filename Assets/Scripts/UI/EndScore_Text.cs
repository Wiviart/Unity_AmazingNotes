using System.Collections;
using AmazingNotes.Game;

namespace AmazingNotes.UI
{
    public class EndScore_Text : UI_Text
    {
        private void OnEnable()
        {
            var score = GameManager.Instance.Score.GetScore();
            ShowText(score, 0);
        }

        private void ShowText(int value, float time)
        {
            StartCoroutine(ShowTextCoroutine(value));
        }

        private IEnumerator ShowTextCoroutine(int value)
        {
            int num = 0;
            while (num < value)
            {
                num++;
                text.text = num.ToString("00");
                yield return null;
            }

            text.text = value.ToString("00");
        }
    }
}