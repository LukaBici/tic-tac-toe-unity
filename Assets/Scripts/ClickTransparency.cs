using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickTransparency : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    private bool isTransparent = false;

    void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Color col = img.color;

        if (isTransparent)
        {
            col.a = 1f; // fully visible
        }
        else
        {
            col.a = 0.5f; // semi-transparent
        }

        img.color = col;
        isTransparent = !isTransparent;
    }
}