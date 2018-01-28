using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : MonoBehaviour {

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		var playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;

		targetPosition = new Vector3 (
			playerPosition.x > transform.position.x ? 20f : -20f,
			transform.position.y,
			0
		);
		//playerPosition = new Vector3(playerPosition.x, transform.position.y, 0);
		//targetPosition = playerPosition 
		//	- (transform.position - playerPosition) * 3;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, 0.1f);
		if (transform.position == targetPosition) {
			Destroy (this.gameObject);
		}
	}
}
