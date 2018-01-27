using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRegenBuff : Buff {
    public float buffValue = 1.0f;

    protected override void Apply() {
        character.swordSummonSpeed -= buffValue;
        Debug.Log("Apllying");
    }

    protected override void UnApply() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().swordSummonSpeed += buffValue;
        Debug.Log("Unapplying");
    }
}
