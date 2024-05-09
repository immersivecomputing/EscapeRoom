using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailController : MonoBehaviour
{
    [SerializeField] private GameObject inbox;
    [SerializeField] private GameObject sent;
    [SerializeField] private GameObject trash;
    [SerializeField] private GameObject[] emails;
    private int openEmail = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInbox() {
        inbox.SetActive(true);
        sent.SetActive(false);
        // trash.SetActive(false);
    }

    public void OpenSent() {
        inbox.SetActive(false);
        sent.SetActive(true);
        // trash.SetActive(false);
    }

    public void OpenTrash() {
        inbox.SetActive(false);
        sent.SetActive(false);
        // trash.SetActive(true);
    }

    public void OpenEmail(int index) {
        if (index == openEmail) {
            return;
        }
        if (openEmail > -1) {
            emails[openEmail].SetActive(false);
        }
        emails[index].SetActive(true);
        openEmail = index;
    }
}
