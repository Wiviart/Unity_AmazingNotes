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
                case > -4f and <= -3.7f:
                    Debug.Log("Perfect");
                    score = 3;
                    break;
                case > -3.7f and <= -3.4f:
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