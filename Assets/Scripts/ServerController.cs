using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    [Serializable]
    struct SwitchInfo {
        public ToggleSwitch toggleSwitch;
        public bool isSolution;
        public bool isOn;
    }

    [SerializeField] private SwitchInfo[] switches;
    [SerializeField] private TextMeshProUGUI serverText;
    [SerializeField] private GameObject whiteImage;
    private bool buttonLock = false;
    private bool executable = false;

    public void SwitchClicked(int aSwitch) {
        switches[aSwitch].isOn = !switches[aSwitch].isOn;
    }

    public void RunButton() {
        if (buttonLock) {
            return;
        }
        StartCoroutine(runButtonHelper());
    }

    private IEnumerator runButtonHelper() {
        int serversActive = 0;
        bool failure = false;
        for (int i = 0; i < switches.Length; i++) {
            switches[i].toggleSwitch.SetButtonLock(true);
            if (switches[i].isOn) {
                serversActive++;
                if (switches[i].isSolution) {
                    failure = true;
                }
            }
        }
        buttonLock = true;

        if (!executable) {
            serverText.text = "Error: Executable Required";
        } else {
            if (serversActive == 0) {
                serverText.text = "Error: Insufficient Memory";
            } else if (serversActive < 3) {
                serverText.text = "Error: Insufficient Memory";
            } else if (serversActive >= 3 && failure) {
                serverText.text = "Processing";
                yield return new WaitForSeconds(0.5f);
                serverText.text = "Processing.";
                yield return new WaitForSeconds(0.5f);
                serverText.text = "Processing..";
                yield return new WaitForSeconds(0.5f);
                serverText.text = "Processing...";
                yield return new WaitForSeconds(0.5f);
                serverText.text = "Error: Server Failure";
            } else if (serversActive >= 3 && !failure) {
                for (int i = 0; i < 5; i++) {
                    serverText.text = "Processing";
                    yield return new WaitForSeconds(0.5f);
                    serverText.text = "Processing.";
                    yield return new WaitForSeconds(0.5f);
                    serverText.text = "Processing..";
                    yield return new WaitForSeconds(0.5f);
                    serverText.text = "Processing...";
                    yield return new WaitForSeconds(0.5f);
                }
                serverText.text = "Code Successfully Executed";
                yield return new WaitForSeconds(2f);
                serverText.text = "Superconducter Confirmation Confirmed: CaFFeIne";
            }

            
        }
        buttonLock = false;
        for (int i = 0; i < switches.Length; i++) {
            switches[i].toggleSwitch.SetButtonLock(false);
        }
    }

    public void SetExecutable(bool isSet) {
        executable = isSet;
        whiteImage.SetActive(isSet);
    }
}
