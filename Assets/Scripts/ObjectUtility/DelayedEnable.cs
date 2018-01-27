using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEnable : MonoBehaviour {

    public GameObject target;
    public float delay = 10.0f;

	// Use this for initialization
	void Start () {
        Invoke("Enable", delay);
	}

    private void Enable() {
        target.gameObject.SetActive(true);
    }
}
