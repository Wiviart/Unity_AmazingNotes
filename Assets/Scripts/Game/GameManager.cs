using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData data;
    [SerializeField] private Audio audio;
    [SerializeField] private SpawnerManager spawner;
    [SerializeField] private TextUI scoreUI, comboUI;
    [SerializeField] private Slider slider;
    private Score score;

    private int amount = GameData.StartAmount;
    private float speed = GameData.StartSpeed;
    private float delay = GameData.StartDelay;

    private float timer = 0;
    private int bpm = 0;
    private float duration = 0;

    private void Start()
    {
        score = new Score(scoreUI, comboUI);
        scoreUI.ShowText("00");
        Observer.OnClick += score.AddScore;

        bpm = audio.Init().bpm;
        delay = (float)60 / bpm;
        spawner.Init(data, bpm);

        duration = audio.Init().clip.length;

        StartCoroutine(SpawnPerBeat());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        slider.value = (timer / duration * 100);

        if (Input.GetKeyDown(KeyCode.A))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

            var type = GetNoteAlongDuration();
            var randomTile = timer > duration * 0.1f;

            spawner.SpawnRandom(type, amount, randomTile, speed);
            yield return new WaitForSeconds(delay);
        }
    }

    private NoteType GetNoteAlongDuration()
    {
        if (timer > duration * 0.8f)
            return NoteValue.GetRamdomNoteType(0, 20, 30, 15, 5, 5);
        if (timer > duration * 0.7f)
            return NoteValue.GetRamdomNoteType(0, 30, 25, 10, 5, 0);
        if (timer > duration * 0.6f)
            return NoteValue.GetRamdomNoteType(5, 40, 20, 10, 0, 0);
        if (timer > duration * 0.5f)
            return NoteValue.GetRamdomNoteType(10, 50, 20, 5, 0, 0);
        if (timer > duration * 0.4f)
            return NoteValue.GetRamdomNoteType(15, 40, 15, 5, 0, 0);
        if (timer > duration * 0.3f)
            return NoteValue.GetRamdomNoteType(20, 30, 15, 0, 0, 0);
        if (timer > duration * 0.2f)
            return NoteValue.GetRamdomNoteType(25, 20, 10, 0, 0, 0);
        if (timer > duration * 0.1f)
            return NoteValue.GetRamdomNoteType(30, 10, 0, 0, 0, 0);
        return NoteValue.GetRamdomNoteType(0, 0, 0, 0, 0, 0);
    }
}