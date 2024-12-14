using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public Transform tilePrefab;
    public Transform tileHoldPrefab;

    public const float StartSpeed = 6;
    public const float StartDelay = 5f;
    public const int StartAmount = 1;
}