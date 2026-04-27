using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    public int row;
    public int col;


    public Sprite xSprite;
    public Sprite oSprite;
    private Image image;
    public Image winHighlight;
    private Color currentColor;
    private bool isUsed = false;

    void Start()
    {
        image = GetComponent<Image>();
        GameManager.Instance.cells[row, col] = this;
    }

    public void OnClick()
    {
        if (isUsed) return;
        Debug.Log("CLICKED: " + row + "," + col);
        isUsed = true;

        if (GameManager.Instance.isXTurn)
        {
            image.sprite = xSprite;

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFX("Click1");
        }
        else
        {
            image.sprite = oSprite;

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlaySFX("Click2");
        }

        GameManager.Instance.MakeMove(row, col);
    }
    public void SetWin()
    {
        Debug.Log("SetWin called on " + gameObject.name);

        if (winHighlight == null)
        {
            Debug.LogError("WIN HIGHLIGHT NOT ASSIGNED on " + gameObject.name);
            return;
        }

        winHighlight.gameObject.SetActive(true);
        AudioManager.Instance.PlaySFX("Pop");
        winHighlight.transform.rotation =
            Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}