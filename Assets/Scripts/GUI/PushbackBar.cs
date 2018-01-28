using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PushbackBar : MonoBehaviour {

    private Slider slider;
    private Character player;

    private void Start() {
        slider = this.GetComponent<Slider>();
        player = GameObject.FindWithTag("Player").GetComponent<Character>();

        slider.maxValue = player.shockWaveCoolDown;
        SetSliderValues();
    }

    private void Update() {
        SetSliderValues();
    }

    private void SetSliderValues() {
        slider.value = player.shockWaveCoolDown - (player.NextShockwaveTime - Time.time);
    }
}
