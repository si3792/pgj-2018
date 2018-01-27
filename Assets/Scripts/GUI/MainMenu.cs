using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject introText;
    public GameObject mainMenuPane;

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }

    private void Update() {
        if (Input.anyKey) {
            introText.SetActive(false);
            mainMenuPane.SetActive(true);
        }
    }
}
