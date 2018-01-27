using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour {
    public static bool reset;

	// Use this for initialization
	void Start () {
        if (reset) {
            PlayerPrefs.SetInt("Level", 2);
            reset = false;
        }
	}	
}
