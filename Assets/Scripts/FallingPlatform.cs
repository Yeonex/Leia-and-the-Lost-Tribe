using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    public float FallDelay;
    private float hitTime;
    private bool wasHit;
    

	// Use this for initialization
	void Start () {
        wasHit = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (wasHit) {
            if ((Time.time * 1000) - hitTime > FallDelay) {
                GetComponent<Rigidbody>().useGravity = true;
                if ((Time.time * 1000) - hitTime > (FallDelay + 1f) * 1000) {
                    Destroy(this.gameObject);
                }
            }
           // Debug.Log("I got in here OWO");
        }
	}

    void  OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            hitTime = Time.time * 1000;
            wasHit = true;
           

            
        }
        

    }

  
}
