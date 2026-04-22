using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    public int row;
    public int col;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private bool isUsed = false;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnClick()
    {
        if (isUsed) return;

        isUsed = true;

        if (GameManager.Instance.isXTurn)
            image.sprite = xSprite;
        else
            image.sprite = oSprite;

        GameManager.Instance.MakeMove(row, col);
    }
}