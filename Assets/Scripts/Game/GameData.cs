using UnityEngine;

namespace AmazingNotes.Game
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData", order = 1)]
    public class GameData : ScriptableObject
    {
        public Transform tilePrefab;
        public Transform tileHoldPrefab;
        public Transform specialNotePrefab;

        public float StartSpeed = 6;
        public int Lives = 3;
    }
}