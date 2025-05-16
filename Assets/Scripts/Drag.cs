using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : Button
{
    [SerializeField] private UnityEvent dropEvent;
    private bool click = false;
    private RectTransform rectTransform;
    private Vector3 mousePos;
    
    void Start() {
        base.Start();
        rectTransform = transform.GetComponent<RectTransform>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        click = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        click = false;
        Drop dropComponent = transform.GetComponent<Drop>();
        if (dropComponent != null) {
            dropComponent.OnDragRelease();
        }
    }

    void FixedUpdate() {
        if (click) {
            Vector3 diffPos = rectTransform.position + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos);
            diffPos.z = 1f;
            rectTransform.position = diffPos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
