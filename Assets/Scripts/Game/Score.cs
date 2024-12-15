public class Score
{
    private int score = 0;
    private int highScore = 0;
    private int combo = 0;

    private UI_Text scoreUI, comboUI;

    public Score(UI_Text scoreUI, UI_Text comboUI)
    {
        this.scoreUI = scoreUI;
        this.comboUI = comboUI;
    }

    public void AddScore(int value)
    {
        if (value > 2) AddCombo();
        else ResetCombo();

        var multiplier = combo == 0 ? 1 : combo;
        score += value * multiplier;

        if (score > highScore) highScore = score;

        scoreUI.ShowText(score.ToString("00"), 0);
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void AddCombo()
    {
        if (combo < ConstTag.MaxCombo) combo++;
        comboUI.ShowText("x" + combo, 1);
    }

    public void ResetCombo()
    {
        combo = 0;
    }
    
    public int GetScore()
    {
        return score;
    }
}