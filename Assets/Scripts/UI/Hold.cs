using AmazingNotes.Game;
using AmazingNotes.Scores;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingNotes.UI
{
    public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform pointer;
        [SerializeField] private Transform endPoint;
        [SerializeField] private ParticleSystem starEffect;
        [SerializeField] private TrailRenderer trail;

        private Vector3 pointerPosition;
        private bool isHold = false;
        private bool AtEndPoint => pointer.position.y >= endPoint.position.y;
        private int score = 0;

        private void Update()
        {
            if (!isHold) return;
            MovePointer();

            if (AtEndPoint) DestroyAndAddScore();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            print("Hold");
            isHold = true;
            pointerPosition = pointer.position;
            pointer.gameObject.SetActive(true);
            trail.gameObject.SetActive(true);

            score = ScoreChecker.ScoreByPosition(transform);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            print("Release");
            DestroyAndAddScore();
        }

        private void DestroyAndAddScore()
        {
            isHold = false;
            var multiplier = AtEndPoint ? 2 : 1;
            if (AtEndPoint) SpawnEffect(starEffect, pointer);
            Observer.OnClickTrigger(score * multiplier);
            Destroy(transform.parent.gameObject);
        }

        private void MovePointer()
        {
            pointer.position = pointerPosition;
        }

        private void SpawnEffect(ParticleSystem effect, Transform transform, Transform parent = null)
        {
            var pos = transform.position;
            pos.z = 10;
            var vfx = Instantiate(effect, pos, Quaternion.identity, parent);
            vfx.Play();
        }
    }
}