using AmazingNotes.Scores;
using UnityEngine;

public class StarCounter_InGameMenu : StarCounter
{
    protected override void SetStar(int index)
    {
        for (int i = 0; i <= index; i++)
        {
            stars[i].color = Color.white;
        }
    }
}