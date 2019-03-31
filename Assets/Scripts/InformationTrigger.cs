using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InformationTrigger : MonoBehaviour {

    public int TriggerNumber;
    public string infoText;
    public Text textToUpdated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            textToUpdated.text = infoText;
            this.gameObject.SetActive(false);
        }
    }
}
