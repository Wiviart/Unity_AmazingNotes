using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public Transform tilePrefab;
    public Transform tileHoldPrefab;

    public const int maxCombo = 7;
    public float StartSpeed = 6;
}