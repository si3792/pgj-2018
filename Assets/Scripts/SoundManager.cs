using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public AudioSource anouncerSource;
    public AudioSource wormSource;
    public AudioSource playerSource;
    public AudioSource enemySource;
    public static SoundManager instance = null;

    public AudioClip bossTheme;
    public AudioClip mainTheme;

	// Use this for initialization
	void Start () {
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

    public void PlayAnouncer(AudioClip effect) {
        anouncerSource.clip = effect;
        anouncerSource.PlayOneShot(effect);
    }

    public void PlayWorm(AudioClip effect) {
        wormSource.clip = effect;
        wormSource.PlayOneShot(effect);
    }

    public void PlayPlayerSound(AudioClip effect) {
        playerSource.clip = effect;
        playerSource.PlayOneShot(effect);
    }

    public void PlayEnemySound(AudioClip effect) {
        enemySource.clip = effect;
        enemySource.PlayOneShot(effect);
    }

    public void PlayMusic(AudioClip music, bool loop = true) {
        musicSource.clip = music;
        musicSource.PlayOneShot(music);
        musicSource.loop = loop;
    }

    public void SetMusicVolume(float value) {
        if (value >= 0.0f && value <= 1.0f) {
            musicSource.volume = value;
        }
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
