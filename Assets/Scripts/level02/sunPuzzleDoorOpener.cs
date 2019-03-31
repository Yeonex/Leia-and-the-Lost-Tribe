using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunPuzzleDoorOpener : MonoBehaviour
{

    public SunTurnPuzzle sunTurn;
    public SunPuzzle puzzle1;
    public SunPuzzle puzzle2;
    public Camera cam;
    public float keepalive = 10f;
    public float speed = 2f;
    public float camtime = 3f;
    private bool door;
    // Start is called before the first frame update
    void Start()
    {
        door = false;
        cam.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        // transform.position += transform.forward * speed * Time.fixedDeltaTime;
        if (door)
        {
            this.transform.position -= transform.up * speed * Time.fixedDeltaTime;
            keepalive -= Time.fixedDeltaTime;
            cam.gameObject.SetActive(true);
            camtime -= Time.deltaTime;
        }
        if (camtime <= 0)
        {
            cam.gameObject.SetActive(false);
        }
        if (keepalive <= 0 && camtime <= 0)
        {
            Destroy(cam.gameObject);
            Destroy(this.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(puzzle1.complete && puzzle2.complete && sunTurn.sunTurned)
        {
            door = true;
        }
    }
}
