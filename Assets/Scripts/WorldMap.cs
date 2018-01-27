using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {

    public Button[] buttons;

	// Use this for initialization
	void Start () {
		foreach(Button button in buttons) {
            button.interactable = false;
        }
        buttons[LevelUnlocked].interactable = true;
	}
	
	public void LoadLevel() {
        Debug.Log("Loading level "+ LevelUnlocked);
        SceneManager.LoadScene(LevelUnlocked);
    }

    public static int LevelUnlocked {
        get {
            if (PlayerPrefs.HasKey("Level")) {
                return PlayerPrefs.GetInt("Level");
            }
            else { return 2; }
        }
        set {
            PlayerPrefs.SetInt("Level", value);
        }
    }
}
