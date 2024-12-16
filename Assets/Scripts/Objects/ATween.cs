using System;
using System.Collections;
using UnityEngine;

namespace AmazingNotes.Objects
{
    public abstract class ATween : MonoBehaviour
    {
        [SerializeField] protected AnimationCurve curve;
        private bool isChanging = false;

        protected abstract void StartChange();

        protected IEnumerator Animate(float duration, Action<float> onUpdate, Action onComplete = null)
        {
            if (isChanging) yield break;
            isChanging = true;

            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                var t = curve.Evaluate(time / duration);
                onUpdate?.Invoke(t);
                yield return null;
            }

            yield return new WaitForSeconds(1);
            isChanging = false;
            onComplete?.Invoke();
        }
    }
}