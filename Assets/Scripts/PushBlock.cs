using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour {

    private Vector3 vel;
    public float speed;
    public Vector3[] dir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Translate(vel);
        vel *= 0.985f; 
	}

    

     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WindArrow")
        {

            // vel = collision.contacts[0].normal * speed;
            vel = Vector3.zero;
            float max = 0f;
            foreach (Vector3 dadir in dir) {
                float current = Vector3.Dot(dadir, (this.transform.position - (collision.collider.transform.position - collision.collider.transform.forward)).normalized);
                if (current > max) {
                    vel = dadir * speed;
                    max = current;
                }
            }

            Destroy(collision.collider);
            Debug.Log("Wind arrow moved it");
        }
        else if (collision.collider.tag != "Ground" && collision.collider.tag !="Player") {
            this.transform.Translate(-2 * vel);
            vel = Vector3.zero;
           
        }
        
    }
}
