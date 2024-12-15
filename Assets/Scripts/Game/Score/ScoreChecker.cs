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
                case > 1.5f:
                    Debug.Log("Perfect");
                    score = 3;
                    break;
                case > -1:
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