using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public Animator animator;
    public float idleDelay = 1.0f;
    public bool despawning = true;
    public float spawnDelay = 1.0f;
    private float lastRecordedTime = -1.0f;

    // Use this for initialization
    void Awake () {
        animator = GetComponent<Animator>();
	}
	
    public void Spawn() {
        Debug.Log("Playing");
        animator.SetTrigger("Spawn");
        despawning = false;
    }

	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("UnderGround")) {
            if (lastRecordedTime < 0) {
                lastRecordedTime = Time.time;
            }
            else if (Time.time > lastRecordedTime + spawnDelay) {
                Spawn();
                lastRecordedTime = -1;
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
            Debug.Log("Reached");
            if (lastRecordedTime < 0) {
                lastRecordedTime = Time.time;
            }
            else if (lastRecordedTime > lastRecordedTime + idleDelay) {
                Despawn();
                lastRecordedTime = -1;
            }
        }
    }

    public void Despawn() {
        animator.SetTrigger("Despawn");
    }
}
