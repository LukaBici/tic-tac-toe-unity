using UnityEngine;

public class MiniExitSound : MonoBehaviour {

    public void OnClick() {
       AudioManager.Instance.PlaySFX("Woosh");
    }
}

