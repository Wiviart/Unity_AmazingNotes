using System;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.Scores
{
    public class StarCounter : MonoBehaviour
    {
        [SerializeField] protected Image[] stars;
        private bool[] isActived = new bool[3];

        private void LateUpdate()
        {
            SetStarsByTime();
        }

        private void SetStarsByTime()
        {
            if (HasReachedProgressThreshold(0.95f)) SetStar(2);
            else if (HasReachedProgressThreshold(0.7f)) SetStar(1);
            else if (HasReachedProgressThreshold(0.35f)) SetStar(0);
        }

        protected virtual void SetStar(int index)
        {
            if (isActived[index]) return;
            stars[index].color = Color.white;
            isActived[index] = true;
            GameManager.Instance.lifeUI.AddLife();
        }

        private bool HasReachedProgressThreshold(float threshold)
        {
            return GameManager.Instance.HasReachedProgressThreshold(threshold);
        }
    }
}