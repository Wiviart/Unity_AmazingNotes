using System.Collections;
using AmazingNotes.Game;
using UnityEngine;

namespace AmazingNotes.Objects
{
    public class SizeChanger : AChanger
    {
        [SerializeField] private float startSize = 1f;
        [SerializeField] private float targetSize = 1.5f;

        private void Start()
        {
            Observer.Instance.OnClick += ChangeSize;
            Observer.Instance.OnHold += ChangeSize;
        }

        private void OnDisable()
        {
            Observer.Instance.OnClick -= ChangeSize;
            Observer.Instance.OnHold -= ChangeSize;
        }

        private void ChangeSize(int index)
        {
            StartCoroutine(Animate(1f, UpdateScale));
        }

        private void UpdateScale(float t)
        {
            transform.localScale = Vector3.one * Mathf.LerpUnclamped(startSize, targetSize, t);
        }
    }
}