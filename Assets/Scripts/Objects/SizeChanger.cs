using System.Collections;
using AmazingNotes.Game;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float targetSize = 1.5f;
    private bool isChanging = false;

    private void Start()
    {
        Observer.Instance.OnClick += ChangeSize;
        Observer.Instance.OnHold += ChangeSize;
    }

    private void OnDisable()
    {
        Observer.Instance.OnClick -= ChangeSize;
        Observer.Instance.OnHold -= ChangeSize;
    }

    private void ChangeSize(int index)
    {
        StartCoroutine(ChangeSizeCoroutine());
    }

    private IEnumerator ChangeSizeCoroutine()
    {
        if (isChanging) yield break;
        isChanging = true;

        float time = 0;
        var startScale = transform.localScale;
        var endScale = startScale * targetSize;

        while (time < 1)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(
                startScale, endScale, _curve.Evaluate(time));
            yield return null;
        }

        isChanging = false;
    }
}