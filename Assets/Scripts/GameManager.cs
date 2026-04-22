using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int[,] board = new int[3, 3]; // 0 empty, 1 = X, 2 = O
    public bool isXTurn = true;
    public int moveCount = 0;

    public UIManager uiManager;

    void Awake()
    {
        Instance = this;
    }

    public void MakeMove(int row, int col)
    {
        if (board[row, col] != 0) return;

        board[row, col] = isXTurn ? 1 : 2;
        moveCount++;

        if (CheckWin())
        {
            uiManager.ShowGameOver(isXTurn ? "Player X Wins" : "Player O Wins");
            return;
        }

        if (moveCount >= 9)
        {
            uiManager.ShowGameOver("Draw");
            return;
        }

        isXTurn = !isXTurn;
        uiManager.UpdateHUD();
    }

    bool CheckWin()
    {
        int player = isXTurn ? 1 : 2;

        // rows & columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) return true;
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player) return true;
        }

        // diagonals
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) return true;
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) return true;

        return false;
    }
}