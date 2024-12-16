using System;
using UnityEngine;

namespace AmazingNotes.Objects
{
    public class PositionTween : ATween
    {
        [SerializeField] private Vector3 startPos = Vector3.zero;
        [SerializeField] private Vector3 targetPos = Vector3.zero;

        private void Start()
        {
            StartChange();
        }

        protected override void StartChange()
        {
            StartCoroutine(Animate(1f, UpdatePosition));
        }

        private void UpdatePosition(float t)
        {
            transform.position = Vector3.LerpUnclamped(startPos, targetPos, t);
        }
    }
}