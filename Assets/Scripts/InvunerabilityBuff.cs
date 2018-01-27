using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvunerabilityBuff : Buff {
    protected override void Apply() {
        character.invulnrableCounter += 1;
        Debug.Log("Apllying");
    }

    protected override void UnApply() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().invulnrableCounter -= 1;
        Debug.Log("UnApllying");
    }
}
