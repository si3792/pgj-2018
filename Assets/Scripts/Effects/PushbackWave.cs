using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PushbackWave : MonoBehaviour {

    //public ParticleSystem particles;
    public Animator ring;

    public void Display() {
        ring.SetTrigger("Expand");
    }
}
