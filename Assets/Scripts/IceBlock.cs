using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {

    public bool isFrozen;
    public bool isBurnt;
    public int timeFrozen;
    public Material[] mat;
    public int damageToPlayer;
    public Renderer rend;
    public float hitTime;

	// Use this for initialization
	void Start () {
        isFrozen = false;
        if(timeFrozen <= 0)
        {
            timeFrozen = 1000;
        }

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];

        isBurnt = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (isFrozen) {
            if ((Time.time * 1000) - hitTime > timeFrozen)
            {
                rend.sharedMaterial = mat[0];
                isFrozen = false;
                GetComponent<BoxCollider>().isTrigger = true;

            }
        }

        if (isBurnt) {
            if ((Time.time * 1000) - hitTime > timeFrozen)
            {
                GetComponent<BoxCollider>().enabled = true;
                rend.sharedMaterial = mat[0];
                isBurnt = false;
                GetComponent<BoxCollider>().isTrigger = true;

            }
            
        }
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player") {
            if(!isBurnt && !isFrozen)
            {
                Vector3 hitdir = other.transform.position - this.transform.position;
                hitdir = hitdir.normalized;
                other.GetComponent<PlayerHealth>().TakeDamage(damageToPlayer);
                other.GetComponent<UpdatedPlayerController>().knockback(hitdir);
            }
        }

        if (other.gameObject.tag == "IceArrow")
        {
            rend.sharedMaterial = mat[1];
            isFrozen = true;
            hitTime = Time.time * 1000;
            GetComponent<BoxCollider>().isTrigger = false;

        }

        if (other.gameObject.tag == "FireArrow") {
            rend.sharedMaterial = mat[2];
            isBurnt = true;
            hitTime = Time.time * 1000;
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
