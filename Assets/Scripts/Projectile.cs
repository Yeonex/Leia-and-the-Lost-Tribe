using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float fireRate;
    public float KeepAliveMili;
    private float startTime;
    public AudioSource audioSource;
    public AudioClip ac;

	// Use this for initialization
	void Start () {
        //Invoke("Update", 0.7f);
        startTime = Time.time * 1000;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (speed != 0)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }

        if ((Time.time * 1000) - startTime > KeepAliveMili) {
            
            Destroy(gameObject);
        }


    }

    

    private void OnTriggerEnter(Collider collision)

    {

        if (collision.gameObject.tag == "PushableObject" && this.gameObject.tag == "WindArrow") {
            this.GetComponent<BoxCollider>().isTrigger = false;
        } else  if (collision.gameObject.tag != "Player" 
            && collision.gameObject.tag !="trigger" 
            && collision.gameObject.tag != "FallingPlatform"
            && collision.gameObject.tag != "EnergyArrow"
            && collision.gameObject.tag != "IceArrow"
            && collision.gameObject.tag != "FireArrow"
            && collision.gameObject.tag != "WindArrow") {
            speed = 0;
            audioSource.clip = ac;
            audioSource.Play();
            Destroy(gameObject,1);
        }
        
    }
}
