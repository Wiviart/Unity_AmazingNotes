using System.Collections.Generic;
using AmazingNotes.Game;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private GameObject lifePrefab;
    private List<GameObject> lifes = new List<GameObject>();
    private int maxLife;

    public void Init(int lifeCount)
    {
        maxLife = lifeCount;
        for (int i = 0; i < lifeCount; i++)
        {
            AddLife();
        }
    }

    public void RemoveLife()
    {
        if (lifes.Count == 0) return;

        var life = lifes[^1];
        lifes.Remove(life);
        Destroy(life);

        if (lifes.Count == 0) Observer.Instance.OnGameEndTrigger();
    }

    public void AddLife()
    {
        if (lifes.Count == maxLife) return;
        var life = Instantiate(lifePrefab, transform);
        lifes.Add(life);
    }
}