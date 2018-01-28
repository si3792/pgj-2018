using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour {

	// Use this for initialization
	public float timeToLive = 1f;
	void Start () {
		Destroy (this.gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
