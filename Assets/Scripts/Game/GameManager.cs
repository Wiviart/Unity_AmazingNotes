using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData data;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextUI scoreUI, comboUI;
    private Score score;

    private int amount = GameData.StartAmount;
    private float speed = GameData.StartSpeed;
    private float delay = GameData.StartDelay;

    private float timer = 0;

    private void Start()
    {
        score = new Score(scoreUI, comboUI);
        spawner.Init(data);
        StartCoroutine(SpawnRandom());
        
        Observer.OnClick += score.AddScore;
    }

    private void OnDisable()
    {
        Observer.OnClick -= score.AddScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            amount = Math.Min(amount + 1, GameData.EndAmount);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            speed += 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            delay = Math.Max(delay - 0.5f, GameData.EndDelay);
        }

        // print("amount: " + amount + " speed: " + speed + " delay: " + delay);
    }

    private IEnumerator SpawnRandom()
    {
        spawner.SpawnRandom(amount, speed);
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRandom());
    }
}