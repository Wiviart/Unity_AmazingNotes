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
        var random = Random.Range(0, 100);
        if (random <= whole) return NoteType.Whole;
        if (random <= whole + half) return NoteType.Half;
        if (random <= whole + half + quarter) return NoteType.Quarter;
        if (random <= whole + half + quarter + eighth) return NoteType.Eighth;
        if (random <= whole + half + quarter + eighth + sixteenth) return NoteType.Sixteenth;
        if (random <= whole + half + quarter + eighth + sixteenth + thirtySecond) return NoteType.ThirtySecond;
        if (random <= whole + half + quarter + eighth + sixteenth + thirtySecond + sixtyFourth)
            return NoteType.SixtyFourth;
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