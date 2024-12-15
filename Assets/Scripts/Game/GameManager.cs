using System.Collections;
using AmazingNotes.Audios;
using AmazingNotes.Notes;
using AmazingNotes.Scores;
using AmazingNotes.Spawners;
using AmazingNotes.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingNotes.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameData data;
        [SerializeField] private Audio _audio;
        [SerializeField] private SpawnerManager spawner;
        [SerializeField] private UI_Text scoreUI, comboUI;
        [SerializeField] private Slider slider;
        public static Score score;

        private int amount = 1;
        private int bpm;
        private float speed;
        private float delay;
        private float timer;
        private float duration;

        private void Start()
        {
            score = new Score(scoreUI, comboUI);
            scoreUI.ShowText("00", 0);
            Observer.OnClick += score.AddScore;

            bpm = _audio.Init().bpm;
            duration = _audio.Init().clip.length;
            delay = (float)60 / bpm;
            speed = data.StartSpeed;

            spawner.Init(data, bpm);
            StartCoroutine(SpawnPerBeat());
        }

        private void LateUpdate()
        {
            timer += Time.deltaTime;
            slider.value = timer / duration * 100;
        }

        private void OnDisable()
        {
            Observer.OnClick -= score.AddScore;
        }

        private IEnumerator SpawnPerBeat()
        {
            while (true)
            {
                if (timer > duration * 0.95f) break;

                var type = NoteValue.GetNoteAlongDuration(timer, duration);
                var randomTile = timer > duration * 0.1f;

                spawner.SpawnRandom(type, amount, randomTile, speed);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}