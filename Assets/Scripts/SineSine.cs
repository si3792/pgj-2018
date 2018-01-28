using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSine : MonoBehaviour {

	public float min_amplitude = 2f, max_amplitude = 7f;
  float frequency, amplitude;
	float sineVar;

	void Start () {
		amplitude = Random.Range (min_amplitude, max_amplitude);
		frequency = 10 / amplitude;

	}

	// Update is called once per frame
	void Update () {
		sineVar += Time.deltaTime * frequency;
		this.transform.localPosition = new Vector3 (0, Mathf.Sin(sineVar) * amplitude, 0);
	}
}
