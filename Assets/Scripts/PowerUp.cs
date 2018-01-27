using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Character character = collision.GetComponent<Character>();
            Apply(character);
            gameObject.SetActive(false);
        }

    }

    protected virtual void Apply(Character character) { }
}
