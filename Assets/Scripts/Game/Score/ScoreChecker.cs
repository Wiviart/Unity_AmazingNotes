using UnityEngine;

namespace AmazingNotes.Scores
{
    public class ScoreChecker
    {
        public static int ScoreByPosition(Transform transform)
        {
            int score = 0;

            switch (transform.position.y)
            {
                case > -4f and <= -3.5f:
                    Debug.Log("Perfect");
                    score = 3;
                    break;
                case > -3.5f and <= -3.0f:
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
}