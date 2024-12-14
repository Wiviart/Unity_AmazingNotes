using UnityEngine;

public class NoteValue
{
    public static float Value(NoteType type)
    {
        return type switch
        {
            NoteType.Whole => 4,
            NoteType.Half => 2,
            NoteType.Quarter => 1,
            NoteType.Eighth => 0.5f,
            NoteType.Sixteenth => 0.25f,
            NoteType.ThirtySecond => 0.125f,
            NoteType.SixtyFourth => 0.0625f,
            _ => 0
        };
    }

    public static NoteType GetRandomNoteType(
        int whole, int half, int quarter, int eighth, int sixteenth, int thirtySecond, int sixtyFourth)
    {
        int[] thresholds = { whole, half, quarter, eighth, sixteenth, thirtySecond, sixtyFourth };
        NoteType[] noteTypes =
        {
            NoteType.Whole, NoteType.Half, NoteType.Quarter, NoteType.Eighth,
            NoteType.Sixteenth, NoteType.ThirtySecond, NoteType.SixtyFourth
        };

        int random = Random.Range(0, 100);
        int cumulative = 0;

        for (int i = 0; i < thresholds.Length; i++)
        {
            cumulative += thresholds[i];
            if (random > cumulative) continue;
            return noteTypes[i];
        }

        return NoteType.Rest;
    }
}

public enum NoteType
{
    Whole,
    Half,
    Quarter,
    Eighth,
    Sixteenth,
    ThirtySecond,
    SixtyFourth,
    Rest
}