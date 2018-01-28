using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_fx : MonoBehaviour {

	public GameObject plus;

	void Start () {
		for (int i = 0; i < 7; i++) {
			Invoke ("instantiateFX", i * 0.1f);
		}
		Destroy (gameObject, 5f);
	}

	void instantiateFX() {
		var obj = Instantiate (plus, transform.position + new Vector3 (Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
		//obj.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
