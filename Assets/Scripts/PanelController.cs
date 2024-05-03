using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    
    [Serializable]
    struct SwitchInfo {
        public ToggleSwitch toggleSwitch;
        public bool isSolution;
        public bool isOn;
        public int pos1;
        public int pos2;
    }
    [Header("Switches")]
    [SerializeField] private SwitchInfo[] switches;

    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI spectrometerText;
    private bool buttonLock = false;

    [Header("String")]
    [SerializeField] private string[] angrams;
    [SerializeField] private string answerText;
    private bool reverse = false;

    void Start() {
        displayText();
    }

    public void SwitchClicked(ToggleSwitch aSwitch, bool isOn) {
        for (int i = 0; i < switches.Length; i++) {
            if (aSwitch == switches[i].toggleSwitch) {
                switches[i].isOn = isOn;
                
                if (i == 0) {
                    reverse = isOn;
                } else {
                    string temp = "";
                    temp = angrams[switches[i].pos1];
                    angrams[switches[i].pos1] = angrams[switches[i].pos2];
                    angrams[switches[i].pos2] = temp;
                }
            }
        }
        displayText();
    }

    public void OnButtonPress() {
        if (buttonLock) {
            return;
        }
        StartCoroutine(onButtonHelper());
    }

    private void displayText() {
        spectrometerText.text = "";
        if (reverse) {
            for (int i = 5; i < angrams.Length; i++) {
                spectrometerText.text += angrams[i];
            }
            spectrometerText.text += " ";
            for (int i = 0; i < 5; i++) {
                spectrometerText.text += angrams[i];
            }
        } else {
            for (int i = 0; i < angrams.Length; i++) {
                spectrometerText.text += angrams[i];
                if (i == 4) {
                    spectrometerText.text += " ";
                }
            }
        }
    }

    private IEnumerator onButtonHelper() {
        for (int i = 0; i < switches.Length; i++) {
            switches[i].toggleSwitch.SetButtonLock(true);
        }
        buttonLock = true;

        bool solution = true;
        for (int i = 0; i < switches.Length; i++) {
            if ((switches[i].isSolution ^ switches[i].isOn)) {
                solution = false;
                break;
            }
        }

        if (solution) {
            spectrometerText.text = "Starting Up";
            yield return new WaitForSeconds(0.5f);
            spectrometerText.text = "Starting Up.";
            yield return new WaitForSeconds(0.5f);
            spectrometerText.text = "Starting Up..";
            yield return new WaitForSeconds(0.5f);
            spectrometerText.text = "Starting Up...";
            yield return new WaitForSeconds(0.5f);
            spectrometerText.text = "Spectrometer Active";
        } else {
            spectrometerText.text = "Error: Unable to start";
            yield return new WaitForSeconds(2f);
            displayText();
        }
        for (int i = 0; i < switches.Length; i++) {
            switches[i].toggleSwitch.SetButtonLock(false);
        }
        buttonLock = false;
    }
}
