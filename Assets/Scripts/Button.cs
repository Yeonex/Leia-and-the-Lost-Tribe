using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    
    public GameObject button1;
    public bool isPressed;
    public Material[] mat;
    public Renderer rend;
    private bool moved;
    public float moveDir;
    public Collider triggArea;

    // Use this for initialization
    void Start () {
        isPressed = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];
        moved = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (isPressed)
        {
            triggArea.enabled = false;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            isPressed = true;
            Debug.Log("Pressed");
            rend.sharedMaterial = mat[1];
            if (!moved)
            {
                this.transform.position = Vector3.Slerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z- moveDir), 0.5f);
            }
            moved = true;
        }
    }
}
