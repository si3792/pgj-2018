using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwarmer : MonoBehaviour {
    public int spawnDistance = 40;
    public float maxSpawnChance = 50f;
    public float minSpawnChance = 1f;
    public GameObject enemyPrefab;
    public int spawnRate = 1;
    private Vector3 currentSpawnPosition;
    private GameObject charecter;

    // Use this for initialization
    void Start () {
        charecter = GameObject.FindGameObjectWithTag("Player");
	}

    private void FixedUpdate() {
        ChoseSpawnPosition();
        ChoseToSpawn();
    }


    private void ChoseSpawnPosition() {
        int direction = 1;
        if (Random.Range(1, 3) == 1) {
            direction = -1;
        }
        float spawnPointX = charecter.transform.position.x + (direction) * (Vector3.left.x * spawnDistance);
        float spawnPointY = Random.Range(0, -5);
        currentSpawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
    }

    private void ChoseToSpawn() {
        float spawnChance = (float)CombatManager.ScoreCounter / 100 - spawnRate;
        if(spawnChance<minSpawnChance) { spawnChance = minSpawnChance; }
        if (spawnChance > maxSpawnChance) { spawnChance = maxSpawnChance; }
        if (Random.Range(1, 101) <= spawnChance) {            
            Instantiate(enemyPrefab, currentSpawnPosition, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
