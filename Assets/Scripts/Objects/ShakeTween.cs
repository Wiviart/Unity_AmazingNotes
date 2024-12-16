using UnityEngine;

namespace AmazingNotes.Objects
{
    public class ShakeTween : ATween
    {
        public float shakeDuration = 1f;
        public float shakeIntensity = 1f;
        public float scaleIntensity = 1f; // Maximum scale change during shake

        private Vector3 originalPosition;
        private Vector3 originalScale;
        private float shakeTimer;
        private float noiseSeedX;
        private float noiseSeedY;
        private float noiseSeedScale;

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StartChange();
        }

        protected override void StartChange()
        {
            originalPosition = transform.localPosition;
            originalScale = transform.localScale;
            StartCoroutine(Animate(shakeDuration, Shake, ResetTransform));
        }

        private void Shake(float t)
        {
            noiseSeedX = Random.Range(0f, 100f);
            noiseSeedY = Random.Range(0f, 100f);
            noiseSeedScale = Random.Range(0f, 100f);

            var noiseX = Mathf.PerlinNoise(noiseSeedX, Time.time * 10f) * shakeIntensity * t;
            var noiseY = Mathf.PerlinNoise(noiseSeedY, Time.time * 10f) * shakeIntensity * t;
            var scaleChange = Mathf.PerlinNoise(noiseSeedScale, Time.time * 10f) * scaleIntensity * t;

            transform.localPosition = originalPosition + new Vector3(noiseX, noiseY, 0);
            transform.localScale = originalScale + Vector3.one * scaleChange;
        }

        private void ResetTransform()
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
        }
    }
}