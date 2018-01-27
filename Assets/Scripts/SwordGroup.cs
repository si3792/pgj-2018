using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGroup : MonoBehaviour {

    public Transform[] swordPositions;
    private Sword[] swords;
    public GameObject swordPrefab;
    public Character character;

    void Start() {
        swords = new Sword[swordPositions.Length];
        for (int i = 0; i < swordPositions.Length; i++) {
            SummonSword(i);
        }
    }

    public void ShootSword(Vector3 position) {
        for (int i = 0; i < swords.Length; i++) {
            if (swords[i].Ready) {
                swords[i].transform.SetParent(null);
                swords[i].Shoot(position);
                swords[i] = null;
                SummonSword(i);
                return;
            }
        }
    }

    private void SummonSword(int index) {
        GameObject newSword = (GameObject)Instantiate(swordPrefab, swordPositions[index].position, Quaternion.identity);
        newSword.transform.SetParent(this.transform);
        newSword.GetComponent<Sword>().Initialize(character.swordSummonSpeed);
        swords[index] = newSword.GetComponent<Sword>();
    }

    public bool HasSwords {
        get { return swords.Any(sword => sword.Ready); }
    }
}
