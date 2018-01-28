using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {

	public float counter;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * speed;
		this.transform.localScale = new Vector3 (1 + Mathf.Abs(Mathf.Sin(counter)), 1 + Mathf.Abs(Mathf.Sin(counter)), 1);
	}
}
