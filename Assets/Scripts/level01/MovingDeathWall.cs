using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDeathWall : MonoBehaviour
{
    public bool triggerd;
    public float speed = 2f;
    public float timeActive = 15f;
    public AudioSource ads;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        ads.clip = ac;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (triggerd)
        {
            transform.position -= transform.forward * speed * Time.fixedDeltaTime;
            timeActive -= Time.fixedDeltaTime;
        }
        if (timeActive <= 0)
        {
            triggerd = false;
        }
        if(triggerd && !ads.isPlaying)
        {
            ads.Play();
        }

    }
}
