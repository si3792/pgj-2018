using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {
    private int nextLevel;

    private void Start() {
        nextLevel = SceneManager.GetActiveScene().buildIndex+1;
        Debug.Log(nextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            WorldMap.LevelUnlocked = nextLevel;
            SceneManager.LoadScene(1);
            Debug.Log("You are bestest");
        }
    }
}
