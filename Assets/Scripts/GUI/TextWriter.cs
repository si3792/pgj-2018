using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextWriter : MonoBehaviour {

    [HideInInspector]
    public string text;
    public float writeFrequency;

    private int currentChar = 0;
    private Text textComp;

    private float nextWrite = 0.0f;

    void Start () {
        nextWrite = Time.time + writeFrequency;
        textComp = GetComponent<Text>();
	}

    private void Update() {
        if (Time.time > nextWrite) {
            textComp.text += text[currentChar];
            currentChar++;
            nextWrite = Time.time + writeFrequency;
        }

        if (currentChar == text.Length) {
            this.enabled = false;
        }
    }
}
