using System.Collections;
using AmazingNotes.Game;
using AmazingNotes.Notes;
using AmazingNotes.Scores;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingNotes.UI
{
    public class PointerClick : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ParticleSystem squareEffect;
        [SerializeField] private ParticleSystem starEffect;
        [SerializeField] private Animator anim;

        private bool isClicked = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (isClicked) return;
            isClicked = true;

            int score = ScoreChecker.ScoreByPosition(transform);
            if (score == 3) SpawnEffect(starEffect);
            Observer.Instance.OnClickTrigger(score);

            SpawnEffect(squareEffect, transform);
            StartCoroutine(PlayAnimationAndDestroy());
        }

        private void SpawnEffect(ParticleSystem effect, Transform parent = null)
        {
            Vector3 pos = transform.position;
            pos.z = 10;
            var particle = Instantiate(effect, pos, Quaternion.identity, parent);
            particle.Play();
        }

        private IEnumerator PlayAnimationAndDestroy()
        {
            var animHandler = new AnimatorHandler(anim);
            animHandler.PlayAnimation(ConstTag.DestroyClip);
            yield return new WaitForSeconds(1);

            Destroy(transform.parent.gameObject);
        }
    }
}