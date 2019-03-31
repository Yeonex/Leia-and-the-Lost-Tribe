using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (other.gameObject.GetComponent<UpdatedPlayerController>().animator.GetCurrentAnimatorStateInfo(0).IsName("Player Run"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(5);
            }
            else if (other.gameObject.GetComponent<UpdatedPlayerController>().animator.GetCurrentAnimatorStateInfo(0).IsName("Run Jump"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(5);
            }
            else if (other.gameObject.GetComponent<UpdatedPlayerController>().animator.GetCurrentAnimatorStateInfo(0).IsName("falling") || other.gameObject.GetComponent<UpdatedPlayerController>().animator.GetCurrentAnimatorStateInfo(0).IsName("Hard Land")) {
                other.GetComponent<PlayerHealth>().TakeDamage(999);
            }
        }
    }
}
