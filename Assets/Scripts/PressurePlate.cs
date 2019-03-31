using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject Door;
    public bool opended;
    public Material[] mat;
    public Renderer rend;
    private bool setDown = false;


    // Use this for initialization
    void Start () {
        opended = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (opended) {
            Door.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == "Player") {
            opended = true;
            rend.sharedMaterial = mat[1];
            if (!setDown) {
                this.transform.position =  Vector3.Slerp(this.transform.position,new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, this.transform.position.z),0.5f);
            }
            setDown = true;
            
        }
    }
}
