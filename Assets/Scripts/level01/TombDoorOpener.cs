using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombDoorOpener : MonoBehaviour
{
    public GameObject door;
    private tombDoorPuzzle tdp;
    public Camera cam;
    public float timer = 3f;
    public bool triggered;
    private bool hit;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        tdp = door.GetComponent<tombDoorPuzzle>();
        cam.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(hit)
        {
            cam.gameObject.SetActive(true);
            timer -= Time.fixedDeltaTime;
        }
        if(timer <= 0)
        {
            cam.gameObject.SetActive(false);
            Destroy(cam.gameObject);
            Destroy(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                tdp.open = true;
                hit = true;
            }
            
        }
    }
}
