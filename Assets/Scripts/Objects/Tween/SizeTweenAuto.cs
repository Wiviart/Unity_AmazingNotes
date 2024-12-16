using UnityEngine;

namespace AmazingNotes.Objects
{
    public class SizeTweenAuto : ATween
    {
        [SerializeField] private float startSize = 1f;
        [SerializeField] private float targetSize = 1.5f;
        [SerializeField] private bool loop = false;

        private void Start()
        {
            StartChange();
        }

        protected override void StartChange()
        {
            StartCoroutine(Animate(1f, UpdateScale, RestartIfLoop));
        }

        private void UpdateScale(float t)
        {
            transform.localScale = Vector3.one * Mathf.LerpUnclamped(startSize, targetSize, t);
        }

        private void RestartIfLoop()
        {
            if (loop) StartChange();
        }
    }
}