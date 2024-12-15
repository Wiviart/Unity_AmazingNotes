using AmazingNotes.Game;
using UnityEngine;

namespace AmazingNotes.Notes
{
    public class Note : MonoBehaviour
    {
        private float _speed = 0;

        public void Init(float speed)
        {
            _speed = speed;
        }

        private void Update()
        {
            if (!(transform.position.y < -20)) return;
            GameManager.score.ResetCombo();
            Destroy(gameObject);
        }

        private void LateUpdate()
        {
            transform.position += Vector3.down * Time.deltaTime * _speed;
        }

        public void Stop()
        {
            _speed /= 2;
        }
    }
}