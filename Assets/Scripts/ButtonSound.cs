using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour{

    public AudioClip clickSoundEffect;
    public AudioClip hoverSoundEffect;
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    public void OnMouseDown() {
        SoundManager.instance.PlayEffect(clickSoundEffect);
    }

    public void OnMouseOver() {
        SoundManager.instance.PlayEffect(hoverSoundEffect);
    }
}
