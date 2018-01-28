using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    public int numberSpawned = 1;
    public GameObject coinPrefab;

    private void OnDisable() {
        for (int i = 0; i < 1; i++) {
            Invoke("SpawnCoin", 0.1f);
        }
        Invoke("Destroy", 1f);
    }

    private void SpawnCoin() {
        Instantiate(coinPrefab);
        Debug.Log("Spawning Coin");
    }

    private void Destroy() {
        GameObject.Destroy(this);
    }

  
}
