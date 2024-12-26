using System;
using UnityEngine;

namespace AmazingNotes.Game
{
    public class Observer : Singleton<Observer>
    {
        public Action<int> OnClick;

        public void OnClickTrigger(int score)
        {
            OnClick?.Invoke(score);
        }

        public Action<int> OnHold;

        public void OnHoldTrigger(int score)
        {
            OnHold?.Invoke(score);
        }

        public Action OnGameEnd;

        public void OnGameEndTrigger()
        {
            OnGameEnd?.Invoke();
        }
    }
}