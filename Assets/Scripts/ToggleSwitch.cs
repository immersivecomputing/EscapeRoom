using System.Collections;
using System.Collections.Generic;
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

        controller.SwitchClicked(this, isOn);
    }

    public void SetButtonLock(bool locked) {
        isLocked = locked;
    }
}
