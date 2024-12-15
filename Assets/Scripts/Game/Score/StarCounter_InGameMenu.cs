using System;
using AmazingNotes.Scores;
using Unity.VisualScripting;

public class StarCounter_InGameMenu : StarCounter
{
    private void OnEnable()
    {
        SetStarsByTime(0);
    }

    private void OnDisable()
    {
    }
}