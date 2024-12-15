using System;
using UnityEngine;


namespace AmazingNotes.Game
{
    public class Observer : MonoBehaviour
    {
        public static Action<int> OnClick;

        public static void OnClickTrigger(int score)
        {
            OnClick?.Invoke(score);
        }

        public static Action<int> OnHold;

        public static void OnHoldTrigger(int score)
        {
            OnHold?.Invoke(score);
        }
    }
}