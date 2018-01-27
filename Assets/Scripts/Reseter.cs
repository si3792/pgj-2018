using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Level",0);
	}	
}
