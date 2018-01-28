using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IDamageTaker {

    public int health = 1;
    public int speed = 5;
	public float closeInRange = 4f;
	public float stopDistance = 0f;
    private Vector3 targetDirection;
	bool isFacingRight = true;
	public enemyType type = enemyType.DEFAULT;
	private static int sineCount = 0;

	public static void resetLevel() {
		Enemy.sineCount = 0;
		Debug.Log(Enemy.sineCount);
	}

	private static int getMaxSineCount() {
		if (CombatManager.ScoreCounter < 15)
			return 0;
		if (CombatManager.ScoreCounter < 50)
			return 1;
		if (CombatManager.ScoreCounter < 100)
			return 2;
		return 3;
	}

	public enum enemyType
	{
		DEFAULT,
		SINE
	}

	void Start() {
        if (type == enemyType.SINE) {
			Enemy.sineCount += 1;
			if (sineCount > Enemy.getMaxSineCount()) {
				Destroy(transform.GetComponentInChildren<CoinSpawner> ());
				Die ();
			}
		}
	}

    public void Initialize() { }

	// Update is called once per frame
	void Update () {
        if (!CombatManager.GameOver) {
            SetTartgetDirection();
            MoveTowardsTarget();
        }

		if (transform.position.y > 0)
			transform.position = new Vector3 (transform.position.x, 0, 0);
	}

	protected void Flip()
	{
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private void SetTartgetDirection() {
        GameObject player = GameObject.Find("Character");
        if (player == null) return;

		if (player.transform.position.x > transform.position.x && isFacingRight)
			Flip ();
		else if (player.transform.position.x < transform.position.x && !isFacingRight)
			Flip ();

		// Dont move if respecting stopDistance
		if (Vector3.Distance (player.transform.position, transform.position) < stopDistance) {
			targetDirection = transform.position;
			return;
		}

        targetDirection = player.transform.position;
		if (Vector3.Distance (player.transform.position, transform.position) > closeInRange && Mathf.Abs(transform.position.x - player.transform.position.x) > 1f)
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
        if (type == enemyType.SINE) {
			Enemy.sineCount -= 1;
        }
        gameObject.SetActive(false);
    }
}
