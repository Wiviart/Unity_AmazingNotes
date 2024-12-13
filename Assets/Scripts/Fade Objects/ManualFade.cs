using System;
using UnityEngine;

public class ManualFade : Fade
{
    [Range(0, 1), SerializeField] private float originalAlpha = 0.5f;

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