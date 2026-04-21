using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
 
    public void ToggleMusic() {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVoulume() {
        AudioManager.Instance.MusicVoulume(_musicSlider.value);
    }

    public void SFXVoulume()
    {
        AudioManager.Instance.sfxVoulume(_sfxSlider.value);
    }
    
}
