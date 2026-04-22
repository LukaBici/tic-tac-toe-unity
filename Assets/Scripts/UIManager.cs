using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;
public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text moveText;

    public GameObject gameOverPanel;
    public Text resultText;
    public Text finalTimeText;

    private float timeElapsed = 0f;
    private bool gameEnded = false;

    public object DebugLog { get; private set; }

    void Update()
    {
        if (gameEnded) return;

        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    public void UpdateHUD()
    {
        int xMoves = (GameManager.Instance.moveCount + (GameManager.Instance.isXTurn ? 0 : 1)) / 2;
        int oMoves = GameManager.Instance.moveCount / 2;

        moveText.text = $"Moves - X: {xMoves} | O: {oMoves}";
    }

    public void ShowGameOver(string result)
    {
        gameEnded = true;

        gameOverPanel.SetActive(true);
        resultText.text = result;
        finalTimeText.text = timerText.text;

        // Convert result to winner ID
        int winner = GetWinnerId(result);

        // Send stats
        GameStatsManager.Instance.AddResult(winner, timeElapsed);
    }

    int GetWinnerId(string result)
    {
        result = result.ToLower();

        if (result.Contains("x wins")) return 1;
        if (result.Contains("o wins")) return 2;
        if (result.Contains("draw")) return 0;

        Debug.LogWarning("Unknown result string: " + result);
        return 0;
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}