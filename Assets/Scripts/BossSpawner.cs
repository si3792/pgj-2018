using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    public int spawnThreshold = 100;

    public GameObject wurmPrefab;

	// Update is called once per frame
	void Update () {
        if (CombatManager.ScoreCounter >= spawnThreshold) {
            Instantiate(wurmPrefab);
            Destroy(this.gameObject);
        }
	}
}
