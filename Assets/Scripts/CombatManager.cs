using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    private static int scoreCounter = 0;
    private static bool gameOver = false;

    public static void PickedUpCoin() {
        scoreCounter++;
        Debug.Log("Picked up coin");
    }

    public int ScoreCounter {
        get { return scoreCounter; }
    }

    public static bool GameOver {
        get { return gameOver; }
        set { gameOver = value; }
    }
}
