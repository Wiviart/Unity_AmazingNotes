using System.Collections.Generic;
using AmazingNotes.Game;
using AmazingNotes.Notes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AmazingNotes.Spawners
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private Spawner[] spawnPoints;
        private int beatsPerMinute = 0;
        private int index = 0;
        private int direction = 1;

        public void Init(GameData data, int bpm)
        {
            beatsPerMinute = bpm;

            foreach (var spawner in spawnPoints)
            {
                spawner.Init(data);
            }
        }

        public void SpawnRandom(NoteType type, int amount, bool random, float speed)
        {
            var points = new List<Spawner>(spawnPoints);

            while (points.Count > amount)
            {
                var index = Random.Range(0, points.Count);
                points.RemoveAt(index);
            }

            for (int i = 0; i < amount; i++)
            {
                var spawnPoint = points[i];
                spawnPoint.Spawn(type, beatsPerMinute, random, speed);
            }
        }

        public void SpawnSpecial(Transform note, float noteSpeed)
        {
            foreach (var s in spawnPoints)
            {
                if (!s.CanSpawn) return;
            }

            var spawnPoint = spawnPoints[index];
            spawnPoint.SpawnSpecial(note, noteSpeed);

            index += direction;

            if (index == 3 || index == 0)
                direction *= -1;
        }
    }
}