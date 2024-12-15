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
        public LifeUI lifeUI;

        public Score Score { get; private set; }

        private int noteAmount = 1;
        private int beatsPerMinute;
        private float noteSpeed;
        private float beatDelay;
        private float gameTimer;
        private float gameDuration;

        private State state = State.Playing;
        private bool[] specialWaveTriggered = new bool[3];

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
            InitializeLifeUI();

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

            CheckAndTriggerSpecialWave(0.25f, 0);
            CheckAndTriggerSpecialWave(0.50f, 1);
            CheckAndTriggerSpecialWave(0.75f, 2);
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

        private void InitializeLifeUI()
        {
            lifeUI.Init(data.Lives);
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
            while (!HasReachedProgressThreshold(0.975f))
            {
                if (state == State.Special)
                {
                    SpawnSpecialNotes();
                    yield return new WaitForSeconds(beatDelay / 2);
                }
                else
                {
                    SpawnNormalNotes();
                    yield return new WaitForSeconds(beatDelay);
                }
            }
        }

        private void SpawnNormalNotes()
        {
            var noteType = NoteValue.GetNoteAlongDuration(gameTimer, gameDuration);
            var isRandomTile = HasReachedProgressThreshold(0.1f);

            spawner.SpawnRandom(noteType, noteAmount, isRandomTile, noteSpeed);
        }

        private void SpawnSpecialNotes()
        {
            var note = data.specialNotePrefab;
            spawner.SpawnSpecial(note, noteSpeed);
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

        private void CheckAndTriggerSpecialWave(float threshold, int index)
        {
            if (specialWaveTriggered[index] || !HasReachedProgressThreshold(threshold)) return;
            specialWaveTriggered[index] = true;
            SpecialWave();
        }

        private void SpecialWave()
        {
            state = State.Special;
            StartCoroutine(ReturnToNormal());
        }

        private IEnumerator ReturnToNormal()
        {
            yield return new WaitForSeconds(5);
            state = State.Playing;
        }
    }
}