using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            if (Input.GetKey(KeyCode.E)) {
                other.GetComponent<PlayerHealth>().addHelthPack(0);
                other.GetComponentInChildren<Animator>().Play("Lifting");
                Vector3 snapPos = transform.position;
                snapPos.y += 0.8f;
                other.transform.position = snapPos;
                this.gameObject.SetActive(false);
               
            }
        }
    }
}
