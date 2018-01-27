using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRegenPowerUp : PowerUp {
    public float buffValue = 0.1f;

    protected override void Apply(Character character) {
        character.swordSummonSpeed -= buffValue;
        Debug.Log(character.swordSummonSpeed);
    }
}
