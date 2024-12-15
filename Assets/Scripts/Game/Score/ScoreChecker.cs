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
                case > -4f and <= -3f:
                    Debug.Log("Perfect");
                    score = 3;
                    break;
                case > -3f and <= -2.0f:
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