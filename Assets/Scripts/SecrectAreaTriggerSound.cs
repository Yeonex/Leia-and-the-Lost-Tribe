using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectAreaTriggerSound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip soundQueue;
    public bool wasTriggered;

    // Use this for initialization
    void Start () {
        wasTriggered = false;
        audioSource.clip = soundQueue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (!wasTriggered)
            {
                audioSource.Play();
                wasTriggered = true;
            }
        }
    }
}
