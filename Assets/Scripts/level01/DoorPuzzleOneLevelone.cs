using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzleOneLevelone : MonoBehaviour
{
    public firstpuzzle ice;
    public firstpuzzle ener;
    public firstpuzzle fire;
    public firstpuzzle wind;
    public Camera cam;
    private bool door;
    public float keepalive = 10f;
    public float speed = 2f;
    public float camtime =3f;
    public AudioSource ads;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        ads.clip = ac;
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
        if(camtime <= 0)
        {
            cam.gameObject.SetActive(false);
        }
        if(keepalive <= 0 && camtime <=0)
        {
            Destroy(cam.gameObject);
            Destroy(this.gameObject);
        }
        if(door && !ads.isPlaying)
        {
            ads.Play();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (wind.stepped && ice.stepped && fire.stepped && ener.stepped)
        {
            door = true;
        }
    }
}
