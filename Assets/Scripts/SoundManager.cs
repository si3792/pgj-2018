using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public static SoundManager instance = null;

    public AudioClip bossTheme;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if (instance == null) {
            instance = this;
        }
        else {
            GameObject.Destroy(this);
        }
        musicSource.Play();
	}
	
    public void PlayEffect(AudioClip effect) {
        effectsSource.clip = effect;
        effectsSource.PlayOneShot(effect);
    }

    public void SwitchToBossTheme() {
        musicSource.Pause();
        musicSource.clip = bossTheme;
        musicSource.Play();
    }
}
