using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    private static int scoreCounter=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PickedUpCoin() {
        scoreCounter++;
        Debug.Log("Picked up coin");
    }

    public int ScoreCounter {
        get { return scoreCounter; }
    }
}
