using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;

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
        var alpha = 0.5f;
        var target = 1f;
        var start = 0.5f;
        var duration = 0.5f;
        var time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            alpha = Mathf.Lerp(start, target, time / duration);
            SetAlpha(alpha);
            yield return null;
        }

        time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            alpha = Mathf.Lerp(target, start, time / duration);
            SetAlpha(alpha);
            yield return null;
        }
    }
}