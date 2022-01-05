using System;

[Serializable]
public class GameData
{
    public UnitStatistics unitStatistics;
    public int highScore;
    public int score;
    public int level;
    public int numberOfGamePlayed;
    
    public bool[] achievements =
    {
        false, // play 1 game
        false, // play 5 games
        false, // play 10 games
        false, // beat a lvl 10 enemy
        false, // 1 kill
        false, // 5 kills
        false // 10 kills
    };
}
