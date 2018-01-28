using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : MonoBehaviour {

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		var playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		targetPosition = playerPosition 
			- (transform.position - playerPosition) * 3;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, 0.1f);
		if (transform.position == targetPosition) {
			Destroy (this.gameObject);
		}
	}
}
