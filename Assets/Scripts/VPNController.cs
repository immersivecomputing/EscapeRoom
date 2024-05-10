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
    [SerializeField] private GameObject incorrectText;
    [SerializeField] private GameObject vpn;
    [SerializeField] private GameObject emails;

    [Header("Answers")]
    [SerializeField] private string usernameAnswer;
    [SerializeField] private string passwordAnswer;

    public void OnLoginPress() {
        if (
            usernameText.text.Equals(usernameAnswer) &&
            passwordText.text.Equals(passwordAnswer)
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
}
