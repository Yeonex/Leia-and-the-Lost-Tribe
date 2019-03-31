using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieAI : MonoBehaviour {

    private UpdatedPlayerController player;
  

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<UpdatedPlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance < 10)
        {
            RaycastHit rayCastHit;
            Physics.Raycast(this.transform.position, player.transform.position - this.transform.position,out rayCastHit, 10);
            if (rayCastHit.collider == null) {
                return;
            } else if (rayCastHit.collider.gameObject.tag == "Player")
            {
                this.transform.rotation = Quaternion.LookRotation(player.transform.position - this.transform.position);

            }
        }
    }
}
