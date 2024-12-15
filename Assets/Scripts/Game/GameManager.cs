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
        public static GameManager Instance;
        [SerializeField] private GameData data;
        [SerializeField] private Audio audioManager;
        [SerializeField] private SpawnerManager spawner;
        [SerializeField] private UI_Text scoreUI, comboUI;
        [SerializeField] private Slider slider;

        public Score Score { get; private set; }

        private int noteAmount = 1;
        private int beatsPerMinute;
        private float noteSpeed;
        private float beatDelay;
        private float gameTimer;
        private float gameDuration;

        private State state = State.Playing;

        #region MONOBEHAVIOUR

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Observer.Instance.OnGameEnd += OnGameEnd;

            InitializeScore();
            InitializeGameSettings();

            spawner.Init(data, beatsPerMinute);
            StartCoroutine(SpawnPerBeat());
        }

        private void Update()
        {
            if (state == State.End) return;

            UpdateTime();
            UpdateSlider();

            if (HasReachedProgressThreshold(1))
                Observer.Instance.OnGameEndTrigger();
        }

        private void OnDisable()
        {
            Score.OnDisable();
        }

        #endregion

        private void InitializeScore()
        {
            Score = new Score(scoreUI, comboUI);
            scoreUI.ShowText("00", 0);
        }

        private void InitializeGameSettings()
        {
            var clipData = audioManager.Init();
            beatsPerMinute = clipData.beatsPerMinute;
            gameDuration = clipData.clip.length;
            beatDelay = 60f / beatsPerMinute;
            noteSpeed = data.StartSpeed;
        }

        private void UpdateTime()
        {
            gameTimer += Time.deltaTime;
        }

        private void UpdateSlider()
        {
            slider.value = gameTimer / gameDuration * 100;
        }

        private IEnumerator SpawnPerBeat()
        {
            while (true)
            {
                if (HasReachedProgressThreshold(0.975f)) break;

                var noteType = NoteValue.GetNoteAlongDuration(gameTimer, gameDuration);
                var isRandomTile = HasReachedProgressThreshold(0.1f);

                spawner.SpawnRandom(noteType, noteAmount, isRandomTile, noteSpeed);
                yield return new WaitForSeconds(beatDelay);
            }
        }

        public bool HasReachedProgressThreshold(float percent)
        {
            return gameTimer > gameDuration * percent;
        }

        private void OnGameEnd()
        {
            StopAllCoroutines();
            state = State.End;
        }
    }
}