using System;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.Scores
{
    public class StarCounter : MonoBehaviour
    {
        [SerializeField] protected Image[] stars;

        private void LateUpdate()
        {
            SetStarsByTime();
        }

        protected void SetStarsByTime()
        {
            if (GameManager.Instance.HasReachedProgressThreshold(0.95f)) SetStar(2);
            else if (GameManager.Instance.HasReachedProgressThreshold(0.7f)) SetStar(1);
            else if (GameManager.Instance.HasReachedProgressThreshold(0.35f)) SetStar(0);
        }

        protected virtual void SetStar(int index)
        {
            stars[index].color = Color.white;
        }
    }
}