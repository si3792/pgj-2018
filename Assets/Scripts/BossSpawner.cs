using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    public int spawnThreshold = 0;

    private bool canSpawn = false;

    public float timeBetweenSpawns = 5.0f;

    public GameObject bossPrefab;

    private GameObject charecter;

    private bool spawning = false;

    public Boss boss;

    private float lastRecordedTime = -1.0f;

    // Use this for initialization
    void Start () {
        boss = Instantiate(bossPrefab).GetComponent<Boss>();
        charecter = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        canSpawn = spawnThreshold <= CombatManager.ScoreCounter && (lastRecordedTime<0 || Time.time>=lastRecordedTime+timeBetweenSpawns);
        if (canSpawn && boss.animator.GetCurrentAnimatorStateInfo(0).IsName("Despawned")) {
            Debug.Log("Spawnging");
            boss.transform.position = new Vector3(charecter.transform.position.x, 0, 0);
            boss.animator.SetTrigger("Show");
            lastRecordedTime = Time.time;
        }
	}
}
