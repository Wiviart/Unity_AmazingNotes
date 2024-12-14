public class Score
{
    private const int maxCombo = 7;

    private int score = 0;
    private int highScore = 0;
    private int combo = 0;

    private TextUI scoreUI, comboUI;

    public Score(TextUI scoreUI, TextUI comboUI)
    {
        this.scoreUI = scoreUI;
        this.comboUI = comboUI;
    }

    public void AddScore(int value)
    {
        if (value > 1) AddCombo();
        else ResetCombo();

        var multiplier = combo == 0 ? 1 : combo;
        score += value * multiplier;

        if (score > highScore) highScore = score;

        scoreUI.ShowText(score.ToString("00"));
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void AddCombo()
    {
        if (combo < maxCombo) combo++;
        comboUI.ShowText("x" + combo);
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}