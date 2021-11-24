using System;

[Serializable]
public class GameData
{
    public UnitStatistics unitStatistics;
    public int highScore;
    public int score;
    public int level;

    public bool[] achievements = { false, false, false, false, false, false };
}
