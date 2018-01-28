using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public static SoundManager instance = null;

    public AudioClip bossTheme;
    public AudioClip mainTheme;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if (instance == null) {
            instance = this;
        }
        else {
            GameObject.Destroy(this);
        }
        musicSource.clip = mainTheme;
        musicSource.Play();
	}
	
    public void SwitchToDefaultTheme() {
        musicSource.clip = mainTheme;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip effect) {
        effectsSource.clip = effect;
        effectsSource.PlayOneShot(effect);
    }

    public void RandomiseSoundEffect(params AudioClip[] audioClips) {
        int soundToPlay = Random.Range(0, audioClips.Length);
        effectsSource.clip = audioClips[soundToPlay];
        effectsSource.PlayOneShot(audioClips[soundToPlay]);
    }

    public void SwitchToBossTheme() {
        musicSource.Pause();
        musicSource.clip = bossTheme;
        musicSource.Play();
    }
}
