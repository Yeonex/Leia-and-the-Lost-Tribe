using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlockPlatform : MonoBehaviour {

    public GameObject gotoPos;
    public bool gotHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnergyArrow") {
            if (!gotHit) {
                this.transform.position = gotoPos.transform.position;
                gotHit = true;
            }
            
        }
    }
}
