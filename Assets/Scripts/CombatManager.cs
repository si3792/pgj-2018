using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    private static int scoreCounter = 0;
    private static bool gameOver = false;

    private void Start() {
        scoreCounter = 0;
        gameOver = false;
    }

    public static void PickedUpCoin() {
        scoreCounter++;
    }

    public static int ScoreCounter {
        get { return scoreCounter; }
    }

    public static bool GameOver {
        get { return gameOver; }
        set { gameOver = value; }
    }
}
