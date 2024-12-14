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

    public static NoteType GetRamdomNoteType(int half, int quarter, int eighth, int sixteenth, int thirtySecond,
        int sixtyFourth)
    {
        var random = Random.Range(0, 100);
        if (random <= 5) return NoteType.Rest;
        if (random <= 5 + half) return NoteType.Half;
        if (random <= 5 + half + quarter) return NoteType.Quarter;
        if (random <= 5 + half + quarter + eighth) return NoteType.Eighth;
        if (random <= 5 + half + quarter + eighth + sixteenth) return NoteType.Sixteenth;
        if (random <= 5 + half + quarter + eighth + sixteenth + thirtySecond) return NoteType.ThirtySecond;
        if (random <= 5 + half + quarter + eighth + sixteenth + thirtySecond + sixtyFourth) return NoteType.SixtyFourth;
        return NoteType.Whole;
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