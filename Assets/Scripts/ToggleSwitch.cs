using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] private PanelController controller;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    private bool isLocked = false;

    private bool isOn = false;
    public void ToggleButton()
    {
        if (isLocked) {
            return;
        }
        if (!isOn)
        {
            buttonImage.sprite = onSprite;
            isOn = true;
        }else 
        {
            buttonImage.sprite = offSprite;
            isOn = false;
        }
        if (controller != null) {
            controller.SwitchClicked(this, isOn);
        }
    }

    public void SetButtonLock(bool locked) {
        isLocked = locked;
    }
}
