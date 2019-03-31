using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStepSound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] ac;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Step()
    {
        int number = Random.Range(0, 3);

      
            audioSource.clip = ac[number];
            audioSource.Play();
      
    }
}
