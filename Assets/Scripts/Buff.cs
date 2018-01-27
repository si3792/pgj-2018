using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    public float duration = 5.0f;
    private float applyTime;
    protected Character character;

	public void Initialize(Character character) {
        this.character = character;
        applyTime = Time.time;
        Apply();
    }
	
    protected virtual void Apply() { }

	// Update is called once per frame
	void Update () {
        if (Time.time >= applyTime + duration) {
            UnApply();
            gameObject.SetActive(false);
        }
	}

    protected virtual void UnApply() { }
}
