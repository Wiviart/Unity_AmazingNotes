using System;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public static Action<int> OnClick;

    public static void OnClickTrigger(int score)
    {
        OnClick?.Invoke(score);
    }

    public Action<int> OnHold;

    public void OnHoldTrigger(int score)
    {
        OnHold?.Invoke(score);
    }
}