using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private List<Transform> _spawned = new List<Transform>();
    GameData data;

    public void Init(GameData data)
    {
        this.data = data;
    }

    public void SpawnRandom(int amount, float speed)
    {
        var points = new List<Transform>(spawnPoints);

        while (points.Count > amount)
        {
            var index = Random.Range(0, points.Count);
            points.RemoveAt(index);
        }

        for (int i = 0; i < amount; i++)
        {
            var spawnPoint = points[i];
            var obj = Instantiate(data.tilePrefab, spawnPoint);
            obj.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            obj.gameObject.AddComponent<Tile>().Init(speed);
            _spawned.Add(obj);
        }
    }
}