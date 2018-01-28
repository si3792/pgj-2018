using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IDamageTaker {

    public int health = 1;
    public int speed = 5;
    private Vector3 targetDirection;

    public void Initialize() { }
	
	// Update is called once per frame
	void Update () {
        if (!CombatManager.GameOver) {
            SetTartgetDirection();
            MoveTowardsTarget();
        }
	}

    private void SetTartgetDirection() {
        GameObject player = GameObject.Find("Character");
        if (player == null) return;
        targetDirection = player.transform.position;
		if (Vector3.Distance (player.transform.position, transform.position) > 4f && Mathf.Abs(transform.position.x - player.transform.position.x) > 1f)
			targetDirection.y = transform.position.y;
    }

    private void MoveTowardsTarget() {
        Vector3 direction = targetDirection - transform.position;
        direction.Normalize();
        GetComponent<Rigidbody2D>().AddForce(direction*speed,ForceMode2D.Force);
    }

    public int Health {
       get { return health; }
    }

    public void TakeDamage(int value) {
        health -= value;
        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        gameObject.SetActive(false);
    }
}
