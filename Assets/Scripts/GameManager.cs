using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // public int[,] board = new int[3, 3]; // 0 empty, 1 = X, 2 = O
    public int[,] board = new int[3, 3];
    public CellButton[,] cells = new CellButton[3, 3];
    public bool isXTurn = true;
    public int moveCount = 0;

    public UIManager uiManager;

    void Awake()
    {
        Instance = this;
        Debug.Log("GameManager alive");
    }


    public void MakeMove(int row, int col)
    {

        Debug.Log($"MOVE: {row},{col} | value placed: {(isXTurn ? 1 : 2)}");
        if (board[row, col] != 0) return;

        board[row, col] = isXTurn ? 1 : 2;
        moveCount++;

        if (CheckWin(out List<CellButton> winningCells))
        {
            Debug.Log("WIN DETECTED");

            foreach (var cell in winningCells)
            {
                Debug.Log("Winning cells count: " + winningCells.Count);
                cell.SetWin();
            }

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

    bool CheckWin(out List<CellButton> winningCells)
    {
        UnityEngine.Debug.Log("CHECKWIN ENTERED");

        int player = isXTurn ? 1 : 2;
        winningCells = new List<CellButton>();

        for (int i = 0; i < 3; i++)
        {
            // ROW CHECK
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
            {
                UnityEngine.Debug.Log("WIN FOUND (ROW " + i + ")");

                winningCells.Add(cells[i, 0]);
                winningCells.Add(cells[i, 1]);
                winningCells.Add(cells[i, 2]);

                return true;
            }

            // COLUMN CHECK (optional but needed)
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
            {
                UnityEngine.Debug.Log("WIN FOUND (COL " + i + ")");

                winningCells.Add(cells[0, i]);
                winningCells.Add(cells[1, i]);
                winningCells.Add(cells[2, i]);

                return true;
            }
        }

        // DIAGONALS
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            UnityEngine.Debug.Log("WIN FOUND (DIAG 1)");

            winningCells.Add(cells[0, 0]);
            winningCells.Add(cells[1, 1]);
            winningCells.Add(cells[2, 2]);

            return true;
        }

        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            UnityEngine.Debug.Log("WIN FOUND (DIAG 2)");

            winningCells.Add(cells[0, 2]);
            winningCells.Add(cells[1, 1]);
            winningCells.Add(cells[2, 0]);

            return true;
        }

        UnityEngine.Debug.Log("NO WIN");
        return false;
    }

}