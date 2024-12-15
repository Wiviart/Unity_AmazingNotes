using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.Objects
{
    public class Fade : MonoBehaviour
    {
        private Image image;
        [Range(0, 1), SerializeField] protected float originalAlpha = 0.5f;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        protected void SetAlpha(float alpha)
        {
            var color = image.color;
            color.a = alpha;
            image.color = color;
        }

        protected void ChangeAlphaCoroutine()
        {
            StartCoroutine(ChangeAlpha());
        }

        private IEnumerator ChangeAlpha()
        {
            var alpha = originalAlpha;
            var target = 1f;
            var duration = 0.5f;
            
            var time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                alpha = Mathf.Lerp(originalAlpha, target, time / duration);
                SetAlpha(alpha);
                yield return null;
            }

            time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                alpha = Mathf.Lerp(target, originalAlpha, time / duration);
                SetAlpha(alpha);
                yield return null;
            }
        }
    }
}