using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificTombOpnerPlate : MonoBehaviour
{
    public GameObject Door;
    public bool opended;
    public Material[] mat;
    public Renderer rend;
    private bool setDown = false;
    private tombDoorPuzzle tdp;
    public GameObject bolder1;
    public GameObject bolder2;
    private Rigidbody b1;
    private Rigidbody b2;
    public float timeForbolder = 30f;


    // Use this for initialization
    void Start()
    {
        opended = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];
        tdp = Door.GetComponent<tombDoorPuzzle>();
        b1 = bolder1.GetComponent<Rigidbody>();
        b2 = bolder2.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opended)
        {
            tdp.open = false;
            tdp.closing = true;
            b1.useGravity = true;
            b2.useGravity = true;
            timeForbolder -= Time.fixedDeltaTime;
            if(timeForbolder <= 0)
            {
                Destroy(bolder1.gameObject);
                Destroy(bolder2.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            opended = true;
            rend.sharedMaterial = mat[1];
            if (!setDown)
            {
                this.transform.position = Vector3.Slerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 0.2f, this.transform.position.z), 0.5f);
            }
            setDown = true;

        }
    }
}
