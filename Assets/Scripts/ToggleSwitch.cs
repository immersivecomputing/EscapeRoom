using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    private bool isOn = false;
    public void ToggleButton()
    {
        if (!isOn)
        {
            buttonImage.sprite = onSprite;
            isOn = true;
        }else 
        {
            buttonImage.sprite = offSprite;
            isOn = false;
        }
    }
}
