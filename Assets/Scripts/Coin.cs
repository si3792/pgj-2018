using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	void Start() {
		CombatManager.PickedUpCoin();
		GameObject.Destroy(this);
	}
}
