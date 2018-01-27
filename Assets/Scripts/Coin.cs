using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private Vector3 targetDirection;
    public int speed = 6;

    void Update() {
        SetTartgetDirection();
        MoveTowardsTarget();
    }

    private void SetTartgetDirection() {
        GameObject player = GameObject.Find("Character");
        if (player == null) return;
        targetDirection = player.transform.position;
    }

    private void MoveTowardsTarget() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetDirection, step);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            CombatManager.PickedUpCoin();
            GameObject.Destroy(this);
        }
    }
}
