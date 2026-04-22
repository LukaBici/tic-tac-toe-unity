using UnityEngine;
using UnityEngine.UI;

public class MainMenuStatsUI : MonoBehaviour
{
    public Text totalGamesText;
    public Text player1WinsText;
    public Text player2WinsText;
    public Text drawsText;
    public Text avgTimeText;

    void Start()
    {
        UpdateStatsUI();
    }

    public void UpdateStatsUI()
    {
        var s = GameStatsManager.Instance.stats;

        totalGamesText.text = "Total Games: " + s.totalGames;
        player1WinsText.text = "Player 1 Wins: " + s.player1Wins;
        player2WinsText.text = "Player 2 Wins: " + s.player2Wins;
        drawsText.text = "Draws: " + s.draws;
        avgTimeText.text = "Avg Time: " + s.GetAverageGameTime().ToString("0.00") + "s";
    }

    public void ResetStatsAndRefresh()
    {
        GameStatsManager.Instance.ResetStats();
        UpdateStatsUI();
    }
}