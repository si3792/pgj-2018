using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PushbackWave : MonoBehaviour {

    public ParticleSystem particles;

    void Start() {
        particles.Stop();
    }

    public void Display() {
        particles.Play();
    }
}
