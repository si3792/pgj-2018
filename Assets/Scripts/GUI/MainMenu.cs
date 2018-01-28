using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject introText;
    public GameObject mainMenuPane;
    public float defaultDuration = 11.0f;
    public AudioClip mainMenuTheme;
    public AudioClip staticTheme;

    private bool enabled = false;

    void Start() {
        introText.SetActive(true);
        mainMenuPane.SetActive(false);
        Invoke("EnableMenu", defaultDuration);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }

    private void Update() {
        if (Input.anyKey) {
            EnableMenu();
        }
    }

    private void EnableMenu() {
        if (!enabled) {
            enabled = true;
            introText.SetActive(false);
            mainMenuPane.SetActive(true);
            PlaySounds();
        }
    }

    private void PlaySounds() {
        SoundManager.instance.PlayMusic(mainMenuTheme, false);
        Invoke("PlayStatic", mainMenuTheme.length);
    }

    private void PlayStatic() {
        SoundManager.instance.SetMusicVolume(0.3f);
        SoundManager.instance.PlayMusic(staticTheme, true);
    }
}
