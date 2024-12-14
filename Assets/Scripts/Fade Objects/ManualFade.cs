using System;
using UnityEngine;

public class ManualFade : Fade
{
    private void Start()
    {
        Observer.OnClick += (score) => ChangeAlphaCoroutine();
        SetAlpha(originalAlpha);
    }

    private void OnDisable()
    {
        Observer.OnClick -= (score) => ChangeAlphaCoroutine();
    }
}