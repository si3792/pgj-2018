using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IDamageTaker {

    public int health = 3;
    public GameObject enemyPrefab;
    public static int enemyLimit = 10;
    private static int currentEnemyCount = 0;
    public float spawnRate = 1.0f;
    private float lastSpawnTime=0.0f;
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= lastSpawnTime + spawnRate) {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
	}

    private void SpawnEnemy() {
        Vector3 spawnPosition = GetNewSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void TakeDamage(int value) {
        Debug.Log("Taking damage!");
        health -= value;
        if (health <= 0) {
            Die();
        }
    }

    public int Health {
        get { return health; }
    }

    private void Die() {
        gameObject.SetActive(false);
    }

    private Vector3 GetNewSpawnPosition() {
        GameObject player = GameObject.Find("Character");
        if (player == null) return new Vector3();
        Vector3 targetDirection = player.transform.position;
        float step = enemyPrefab.GetComponent<Enemy>().speed * Time.deltaTime;
        return transform.position = Vector3.MoveTowards(transform.position, targetDirection, step);
    }
}
