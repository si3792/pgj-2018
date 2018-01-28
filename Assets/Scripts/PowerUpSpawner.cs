using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    public int health = 3;
    public int spawnDistance = 20;
    public GameObject[] buffs;
    public float minSpawnTime= 5.0f;
    public float maxSpawnTime = 10f;
    private float nexSpawnTime;
    private float lastSpawnTime = -1.0f;
    public GameObject powerUpPrefab;
    private PowerUp nextPowerUp;
    private Vector3 currentSpawnPosition;
    private GameObject charecter;

    // Use this for initialization
    void Start () {
        charecter = GameObject.FindGameObjectWithTag("Player");
        nexSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (!CombatManager.GameOver && (Time.time >= lastSpawnTime + nexSpawnTime || lastSpawnTime<0)) {
            ChoseSpawnPosition();
            ChoseNextPowerUp();
            lastSpawnTime = Time.time;
        }
    }

    private void ChoseNextPowerUp() {
        int buffToUse = Random.Range(0, buffs.Length);
        nextPowerUp = GameObject.Instantiate(powerUpPrefab, currentSpawnPosition, Quaternion.identity).GetComponent<PowerUp>();
        nextPowerUp.buff = buffs[buffToUse];
        Debug.Log("Spawning");
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
}
