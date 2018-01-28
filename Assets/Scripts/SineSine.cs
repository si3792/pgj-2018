using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineSine : MonoBehaviour, IDamageTaker {

	public float min_amplitude = 2f, max_amplitude = 7f;
  	float frequency, amplitude;
	float sineVar;
	public int health = 1;


	void Start () {
		amplitude = Random.Range (min_amplitude, max_amplitude);
		frequency = 10 / amplitude;

	}

	public void TakeDamage(int value) {
		health -= value;
		if (health <= 0) {
			Die();
		}
	}

	private void Die() {
		gameObject.SetActive(false);
	}

	public int Health {
		get { return health; }
	}

	// Update is called once per frame
	void Update () {
		sineVar += Time.deltaTime * frequency;
		this.transform.localPosition = new Vector3 (0, Mathf.Sin(sineVar) * amplitude, 0);
	}
}
