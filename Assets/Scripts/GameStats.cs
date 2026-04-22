using UnityEngine;

[System.Serializable]
public class GameStats
{
    public int totalGames;
    public int player1Wins;
    public int player2Wins;
    public int draws;
    public float totalGameTime;

    public float GetAverageGameTime()
    {
        return totalGames == 0 ? 0 : totalGameTime / totalGames;
    }
}