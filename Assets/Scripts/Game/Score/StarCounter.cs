using System;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.Scores
{
    public class StarCounter : MonoBehaviour
    {
        [SerializeField] private Image[] stars;

        private void OnEnable()
        {
            Observer.OnClick += SetStarsByTime;
            Observer.OnHold += SetStarsByTime;
        }

        private void OnDisable()
        {
            Observer.OnClick -= SetStarsByTime;
            Observer.OnHold -= SetStarsByTime;
        }

        private void SetStar(int index)
        {
            stars[index].color = Color.white;
        }

        protected void SetStarsByTime(int score)
        {
            if (GameManager.Instance.GetCurrentProgress(0.95f)) SetStar(2);
            else if (GameManager.Instance.GetCurrentProgress(0.7f)) SetStar(1);
            else if (GameManager.Instance.GetCurrentProgress(0.35f)) SetStar(0);
        }
    }
}