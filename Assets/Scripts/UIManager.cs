using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text moveText;

    public GameObject gameOverPanel;
    public Text resultText;
    public Text finalTimeText;

    private float timeElapsed = 0f;
    private bool gameEnded = false;

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