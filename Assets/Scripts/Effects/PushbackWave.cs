using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PushbackWave : MonoBehaviour {

    //public ParticleSystem particles;
    public GameObject ring;

    void Start() {
         
        //   particles.Stop();
    }

    public void Display() {
        ring.SetActive(true);

        //   particles.Play();
    }
}
