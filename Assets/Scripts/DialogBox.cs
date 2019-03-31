using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public Image dialogBox;
    public TextMeshProUGUI text;
    public bool reading;
    public string content;

    // Start is called before the first frame update
    void Start()
    {
        reading = false;
        dialogBox.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        text.SetText(content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !reading)
            {
                text.SetText(content);
                reading = true;
                dialogBox.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.E) && reading) {
                reading = false;
                dialogBox.gameObject.SetActive(false);
                text.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        reading = false;
        dialogBox.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
