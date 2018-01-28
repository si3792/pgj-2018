using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject sine;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.X)) {
			GameObject.Instantiate (sine, transform);
		}
	}
}
