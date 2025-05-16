using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private ServerController controller;
    private bool triggered = false;


    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("triggered with " + other.gameObject.name);
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        triggered = false;
        controller.SetExecutable(false);
    }

    public void OnDragRelease() {
        if (triggered) {
            transform.GetComponent<RectTransform>().position = anchorPoint.position;
            controller.SetExecutable(true);
        }
    }
}
