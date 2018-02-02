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

    public bool writeOnEnabled = true;

    private void OnEnable() {
        textComp = GetComponent<Text>();
        if (writeOnEnabled) {
            Write();

        }
    }

    public void Write() {
        if (textComp != null) {
            textComp.text = "";
            nextWrite = Time.time + writeFrequency;
            currentChar = 0;
        }
    }

    private void Update() {

        if (currentChar >= text.Length) {
            return;
        }

        if (Time.time > nextWrite) {
            textComp.text += text[currentChar];
            currentChar++;
            nextWrite = Time.time + writeFrequency;
        }
    }
}
