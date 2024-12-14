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

    private static NoteType GetRandomNoteType(
        int whole, int half, int quarter, int eighth, int sixteenth, int thirtySecond, int sixtyFourth)
    {
        (int threshold, NoteType type)[] NoteTypeConfigs = new[]
        {
            (whole, NoteType.Whole),
            (half, NoteType.Half),
            (quarter, NoteType.Quarter),
            (eighth, NoteType.Eighth),
            (sixteenth, NoteType.Sixteenth),
            (thirtySecond, NoteType.ThirtySecond),
            (sixtyFourth, NoteType.SixtyFourth)
        };

        int random = Random.Range(0, 100);
        int cumulative = 0;

        for (int i = 0; i < NoteTypeConfigs.Length; i++)
        {
            var (threshold, type) = NoteTypeConfigs[i];
            cumulative += threshold;
            if (random > cumulative) continue;
            return type;
        }

        return NoteType.Rest;
    }

    private static (float threshold, int[] percent)[] NotePercentConfigs = new[]
    {
        (0.8f, new[] { 15, 00, 20, 30, 15, 5, 5 }),
        (0.7f, new[] { 20, 00, 30, 25, 10, 5, 0 }),
        (0.6f, new[] { 20, 05, 40, 20, 10, 0, 0 }),
        (0.5f, new[] { 25, 10, 50, 20, 05, 0, 0 }),
        (0.4f, new[] { 25, 15, 40, 15, 05, 0, 0 }),
        (0.3f, new[] { 30, 20, 30, 15, 00, 0, 0 }),
        (0.2f, new[] { 30, 25, 20, 10, 00, 0, 0 }),
        (0.1f, new[] { 35, 30, 10, 00, 00, 0, 0 }),
        (0.0f, new[] { 35, 00, 00, 00, 00, 0, 0 })
    };

    public static NoteType GetNoteAlongDuration(float timer, float duration)
    {
        foreach (var (threshold, weights) in NotePercentConfigs)
        {
            if (timer > duration * threshold)
                return GetRandomNoteType(
                    weights[0], weights[1],
                    weights[2], weights[3],
                    weights[4], weights[5],
                    weights[6]);
        }

        return NoteType.Rest;
    }
}