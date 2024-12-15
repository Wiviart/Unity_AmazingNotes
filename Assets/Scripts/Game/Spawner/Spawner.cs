using AmazingNotes.Game;
using AmazingNotes.Notes;
using UnityEngine;

namespace AmazingNotes.Spawners
{
    public class Spawner : MonoBehaviour
    {
        private GameData data;
        private float delayTime;
        private bool canSpawn = true;

        public void Init(GameData data)
        {
            this.data = data;
        }

        private void Update()
        {
            if (canSpawn) return;
            delayTime -= Time.deltaTime;

            if (delayTime <= 0)
                canSpawn = true;
        }

        public void Spawn(NoteType type, int bpm, bool random, float speed)
        {
            if (!canSpawn || type == NoteType.Rest) return;

            var prefab = PrefabByType(type, random);
            var obj = Instantiate(prefab, transform);
            obj.GetComponent<Note>().Init(speed);
            delayTime = DelayTime(type, bpm);
            canSpawn = false;
        }


        private float DelayTime(NoteType type, int bpm)
        {
            var value = NoteValue.Value(type);
            var min = NoteValue.Value(NoteType.Quarter);
            value = Mathf.Max(value, min);
            var duration = value * 60 / bpm;

            return duration;
        }

        private Transform PrefabByType(NoteType type, bool random = true)
        {
            if (type != NoteType.Whole)
                return data.tilePrefab;

            if (!random) return data.tilePrefab;

            var index = Random.Range(0, 2);
            return index == 0 ? data.tilePrefab : data.tileHoldPrefab;
        }
    }
}