using System;
using UnityEngine;

namespace AmazingNotes.Objects
{
    public class PositionChanger : AChanger
    {
        [SerializeField] private Vector3 startPos = Vector3.zero;
        [SerializeField] private Vector3 targetPos = Vector3.zero;

        private void Start()
        {
            ChangePosition();
        }

        private void ChangePosition()
        {
            StartCoroutine(Animate(1f, UpdatePosition));
        }

        private void UpdatePosition(float t)
        {
            transform.position = Vector3.LerpUnclamped(startPos, targetPos, t);
        }
    }
}