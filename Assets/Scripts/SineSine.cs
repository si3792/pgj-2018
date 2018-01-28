using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSine : MonoBehaviour {

	public float amplitude = 2f;
	public float frequency = 2f;
	float sineVar;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sineVar += Time.deltaTime * frequency;
		this.transform.localPosition = new Vector3 (0, Mathf.Sin(sineVar) * amplitude, 0);
	}
}
