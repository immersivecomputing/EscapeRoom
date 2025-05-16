using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VPNController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TMP_InputField usernameText;
    [SerializeField] private TMP_InputField passwordText;
    [SerializeField] private UnityEngine.UI.Button submit;
    [SerializeField] private GameObject incorrectText;
    [SerializeField] private GameObject vpn;
    [SerializeField] private GameObject emails;

    [Header("Answers")]
    [SerializeField] private string usernameAnswer;
    [SerializeField] private string passwordAnswer;
    private string text;
    private TMP_InputField selectedField = null;

    private IEnumerator fieldCoroutine = null;

    public void OnLoginPress() {
        if (
            usernameText.text.ToLower().Equals(usernameAnswer.ToLower()) &&
            passwordText.text.ToLower().Equals(passwordAnswer.ToLower())
        ) {
            vpn.SetActive(false);
            emails.SetActive(true);
        } else {
            incorrectText.SetActive(true);
            // StartCoroutine(incorrectLogin());
        }
    }

    private IEnumerator incorrectLogin() {
        incorrectText.SetActive(true);
        yield return new WaitForSeconds(2f);
        incorrectText.SetActive(false);
    }

    public void OnSelect(TMP_InputField field) {
        selectedField = field;
        field.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        fieldCoroutine = inputThingy(field);
        StartCoroutine(fieldCoroutine);
    }

    public void OnDeselect(TMP_InputField field) {
        selectedField = null;
        if (field.text.Length < 1) {
            field.placeholder.GetComponent<TextMeshProUGUI>().text = "Enter text...";
        } else {
            if (field.text.Contains("|")) {
                string[] splits = field.text.Split("|");
                text = "";
                for (int i = 0; i < splits.Length; i++) {
                    if (splits[i].Length < 1) {
                        continue;
                    }
                    text += splits[i];
                }
            } 
            field.text = text;
        }
        field.placeholder.GetComponent<TextMeshProUGUI>().text = "Enter text...";
        StopCoroutine(fieldCoroutine);
        fieldCoroutine = null;
    }

    public void OnValueChanged(TMP_InputField field) {
        if (field.text.Contains("|")) {
            string[] splits = field.text.Split("|");
            text = "";
            for (int i = 0; i < splits.Length; i++) {
                if (splits[i].Length < 1) {
                    continue;
                }
                text += splits[i];
            }
        } else {
            text = field.text;
        }
    }

    private IEnumerator inputThingy(TMP_InputField field) {
        text = field.text;
        while (true) {
            field.text = text + "|";
            yield return new WaitForSeconds(0.5f);
            field.text = text;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (selectedField == usernameText) {
                passwordText.Select();
            } else if (selectedField == passwordText) {
                submit.Select();
            } else {
                usernameText.Select();
            }
        }
    }
}
