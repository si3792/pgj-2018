using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    Animator animator;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
	}
	
    public void Spawn() {
        animator.ResetTrigger("Despawn");
        animator.SetTrigger("Spawn");
    }

    public void Despawn() {
        animator.ResetTrigger("Spawn");
        animator.SetTrigger("Despawn");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2")) {
            Spawn();
        }
        if (Input.GetButtonDown("Fire3")) {
            Despawn();
        }
    }
}
