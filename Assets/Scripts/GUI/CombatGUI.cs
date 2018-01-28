using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatGUI : MonoBehaviour {

    public GameObject combatGUI;
    public GameObject gameOverGUI;
    private Character player;

    public Text scoreText;
    public Text doubleKillsText;
    public Text tripleKillText;
    public Text multiKillText;

    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Character>();
        gameOverGUI.SetActive(false);
        combatGUI.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
        if (player.IsDead && !gameOver) {
            GameOver();
        }
	}

    private void GameOver() {
        gameOver = true;
        UnityEngine.Cursor.visible = true;
        combatGUI.SetActive(false);
        gameOverGUI.SetActive(true);
        gameOverGUI.GetComponent<Animator>().SetTrigger("Enter");
        SetDataTexts();
    }

    private void SetDataTexts() {
        scoreText.text = "Score : " + CombatManager.ScoreCounter;
        doubleKillsText.text = "Double Kills : " + KillCounter.doubleKills;
        tripleKillText.text = "Triple Kills : " + KillCounter.tripleKills;
        multiKillText.text = "Multi Kills : " + KillCounter.multiKills;
    }

    public void Restart() {
        CombatManager.GameOver = false;
        gameOverGUI.SetActive(false);
        combatGUI.SetActive(true);
        Enemy.resetLevel();
        SoundManager.instance.SwitchToDefaultTheme();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		KillCounter.doubleKills = 0;
		KillCounter.tripleKills = 0;
		KillCounter.multiKills = 0;
    }

    public void QuitProgram() {
        Application.Quit();
    }
}
