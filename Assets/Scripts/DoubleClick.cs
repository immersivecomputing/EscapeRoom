using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoubleClick : MonoBehaviour
{
    private bool firstClick = false;
    private IEnumerator clicking = null;

    [SerializeField] private UnityEvent doubleClickEvent;

    public void Click() {
        if (!firstClick) {
            clicking = clickCoroutine();
            StartCoroutine(clicking);
        } else {
            StopCoroutine(clicking);
            clicking = null;
            firstClick = false;
            if (doubleClickEvent != null) {
                doubleClickEvent.Invoke();
            }
        }
    }

    private IEnumerator clickCoroutine() {
        firstClick = true;
        yield return new WaitForSeconds(1f);
        firstClick = false;
    }
}
