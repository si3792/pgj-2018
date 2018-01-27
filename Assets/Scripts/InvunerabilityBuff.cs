using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvunrabilityBuff : Buff {
    protected override void Apply() {
        character.invulnrableCounter += 1;
    }

    protected override void UnApply() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().invulnrableCounter -= 1;
    }
}
