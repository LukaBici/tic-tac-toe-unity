using UnityEngine;
using System.IO;

public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance;

    public GameStats stats = new GameStats();

    private string filePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Application.persistentDataPath + "/gamestats.json";

        LoadStats();
    }

    public void AddResult(int winner, float gameTime)
    {
        stats.totalGames++;
        stats.totalGameTime += gameTime;

        if (winner == 1)
            stats.player1Wins++;
        else if (winner == 2)
            stats.player2Wins++;
        else
            stats.draws++;

        SaveStats(); //  save immediately after each game
    }

    public void SaveStats()
    {
        string json = JsonUtility.ToJson(stats, true);
        File.WriteAllText(filePath, json);

        Debug.Log("Stats saved to: " + filePath);
    }

    public void LoadStats()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            stats = JsonUtility.FromJson<GameStats>(json);

            Debug.Log("Stats loaded");
        }
        else
        {
            Debug.Log("No stats file found, starting fresh");
        }
    }

    public void ResetStats()
    {
        stats = new GameStats(); // reset all values to 0

        SaveStats(); // overwrite JSON file with empty stats

        Debug.Log("Stats reset!");
    }

}