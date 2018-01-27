using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IDamageTaker {
    public int health = 5;
    public int invulnrableCounter = 0;
    public float swordSummonSpeed = 2.0f;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;
    private Rigidbody2D rigidbody;

    public SwordGroup swordGroup;

    private Animator animator;
    private SpriteRenderer sprite;

    void Start() {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement() {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 dirVector = new Vector2(xInput, yInput);

        rigidbody.AddForce(dirVector * acceleration, ForceMode2D.Force);

        float velLength = rigidbody.velocity.magnitude;
        if (velLength > maxSpeed) {
            rigidbody.AddForce(rigidbody.velocity.normalized * -1 * (velLength - maxSpeed));
        }

        if (dirVector.x > 0.1f) {
            sprite.flipX = true;
        }
        else if(dirVector.x < -0.1f) {
            sprite.flipX = false;
        }

        if (dirVector.magnitude > 0.02f) {
            SetAnimatorVariables(dirVector.normalized);
        }

    }

    private void SetAnimatorVariables(Vector2 dirVector) {
        float y = dirVector.y;
        float x = Mathf.Abs(dirVector.x);

        if (y > 0.8f && x < 0.225f) {
            animator.SetInteger("Direction", 0); // up
        }
        else if (y < 0.8f && y > 0.225f && x > 0.225f && x < 0.8f) {
            animator.SetInteger("Direction", 1);    //Up left
        }
        else if (y > -0.225f && y < 0.225f && x > 0.8f) {
            animator.SetInteger("Direction", 2);    //Left
        }
        else if (y > -0.8f && y < -0.225f && x > 0.225f && x < 0.8f) {
            animator.SetInteger("Direction", 3);    //Down left
        }
        else if (y < -0.8f && x < 0.225f) {
            animator.SetInteger("Direction", 4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            int damage = collision.gameObject.GetComponent<IDamageTaker>().Health();
            TakeDamage(damage);
            collision.gameObject.GetComponent<IDamageTaker>().TakeDamage(damage);
            Debug.Log(health);
        }
    }

    private void HandleAttack() {
        if (Input.GetMouseButtonDown(0) && swordGroup.HasSwords) {
			Vector3 shootPosition = GetWorldPositionOnPlane(Input.mousePosition, 0);
            shootPosition.z = 0;
            swordGroup.ShootSword(shootPosition);
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
           // animator.SetBool("Attacking", true);
          //  Invoke("DesetAttacking", 0.14f);
        }
    }

    private void DesetAttacking() {
        animator.SetBool("Attacking", false);
    }

    public void TakeDamage(int value) {
        if(invulnrableCounter<=0){
            health -= value;
            if (health <= 0) {
                Die();
            }
        }
    }

    public int Health() {
        return health;
    }

    private void Die() {
        gameObject.SetActive(false);
        Debug.Log("RIP");
        PauseMenu.QuitGame();
    }

	Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
		
}
