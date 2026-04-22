using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickTransparency : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    private const string KEY = "ButtonAlpha";

    void Start()
    {
        img = GetComponent<Image>();

        float alpha = PlayerPrefs.GetFloat(KEY, 1f);
        Apply(alpha);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float currentAlpha = PlayerPrefs.GetFloat(KEY, 1f);

        // toggle based on actual saved value
        float newAlpha = (currentAlpha >= 1f) ? 0.5f : 1f;

        Apply(newAlpha);

        PlayerPrefs.SetFloat(KEY, newAlpha);
        PlayerPrefs.Save();
    }

    private void Apply(float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}