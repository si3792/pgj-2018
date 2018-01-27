using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    public int numberSpawned = 1;
    public GameObject coinPrefab;

    private void OnDisable() {
        for(int i = 0; i < 1; i++) {
            Debug.Log("Called");
            Invoke("SpawnCoin", 0.1f);
        }
    }

    private void SpawnCoin() {
        Vector3 spawnPosition = GetNewSpawnPosition();
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Spawning Coin");
    }

    private Vector3 GetNewSpawnPosition() {
        GameObject player = GameObject.Find("Character");
        if (player == null) return new Vector3();
        Vector3 targetDirection = player.transform.position;
        float step = coinPrefab.GetComponent<Coin>().speed * Time.deltaTime;
        return transform.position = Vector3.MoveTowards(transform.position, targetDirection, step);
    }
}
