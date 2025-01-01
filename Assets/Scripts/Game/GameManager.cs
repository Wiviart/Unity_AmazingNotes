using System;
using System.Collections;
using System.Threading.Tasks;
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
        [SerializeField] private GameObject loadingScreen;
        public LifeUI lifeUI;

        public Score Score { get; private set; }

        private int noteAmount = 1;
        private int beatsPerMinute;
        private float noteSpeed;
        private float beatDelay;
        private float gameTimer;
        private float gameDuration = 1000;

        private State state = State.Init;
        private bool[] specialWaveTriggered = new bool[3];

        #region MONOBEHAVIOUR

        private void Awake()
        {
            Instance = this;
        }

        private async void Start()
        {
            await InitializeGameSettings();
            loadingScreen.SetActive(false);
            state = State.Playing;
            InitializeScore();
            InitializeLifeUI();
            spawner.Init(data, beatsPerMinute);
            StartCoroutine(SpawnPerBeat());
        }

        private void Update()
        {
            if (!IsPlaying()) return;

            UpdateTime();
            UpdateSlider();

            if (HasReachedProgressThreshold(1))
                Observer.Instance.OnGameEndTrigger();

            CheckAndTriggerSpecialWave(0.25f, 0);
            CheckAndTriggerSpecialWave(0.50f, 1);
            CheckAndTriggerSpecialWave(0.75f, 2);
        }

        private void OnEnable()
        {
            Observer.Instance.OnGameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            Score.OnDisable();
            Observer.Instance.OnGameEnd -= OnGameEnd;
        }

        #endregion

        private void InitializeScore()
        {
            Score = new Score(scoreUI, comboUI);
            scoreUI.ShowText("00", 0);
        }

        private async Task InitializeGameSettings()
        {
            var clipData = await audioManager.Init();
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
            if (specialWaveTriggered[index] ||
                !HasReachedProgressThreshold(threshold))
                return;
            specialWaveTriggered[index] = true;
            SpecialWave();
        }

        private void SpecialWave()
        {
            StartCoroutine(ReturnToNormal());
        }

        private IEnumerator ReturnToNormal()
        {
            state = State.Special;
            yield return new WaitForSeconds(10);
            state = State.Playing;
        }

        private bool IsPlaying()
        {
            return state is State.Playing or State.Special;
        }
    }
}