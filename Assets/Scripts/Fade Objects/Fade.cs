using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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