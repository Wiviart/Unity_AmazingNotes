using UnityEngine;

public class ScoreChecker
{
    public static int ScoreByPosition(Transform transform)
    {
        int score = 0;

        switch (transform.position.y)
        {
            case > -4.25f and <= -3.75f:
                Debug.Log("Perfect");
                score = 3;
                break;
            case > -3.75f and <= -3.25f:
                Debug.Log("Great");
                score = 2;
                break;
            default:
                Debug.Log("Good");
                score = 1;
                break;
        }

        return score;
    }
}