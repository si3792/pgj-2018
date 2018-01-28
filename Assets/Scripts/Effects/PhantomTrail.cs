using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomTrail : MonoBehaviour {

    public Color phantomColor = Color.blue;
    public float phantomLifetime = 0.12f;
    public float phantomStep = 0.5f; //how often a phantom is spawned

    private bool trailing = false;

    private float nextPhantom;

    public void StartTrail() {
        SpawnPhantom();
        nextPhantom = Time.time + phantomStep;
    }

    private void Update() {
        if (Time.time > nextPhantom) {
            nextPhantom += phantomStep;
            SpawnPhantom();
        }
    }

    private void SpawnPhantom() {
        GameObject phantom = new GameObject("Phantom");
        phantom.transform.position = this.transform.position;
        SpriteRenderer renderer = phantom.AddComponent<SpriteRenderer>();
        renderer.color = phantomColor;
        renderer.sprite = this.GetComponent<SpriteRenderer>().sprite;
        renderer.flipX = this.GetComponent<SpriteRenderer>().flipX;
        FadeoutObject fadeout = phantom.AddComponent<FadeoutObject>();
        fadeout.lifetime = phantomLifetime;
    }
}
