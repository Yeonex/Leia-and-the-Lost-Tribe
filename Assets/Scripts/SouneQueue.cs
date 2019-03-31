using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouneQueue : MonoBehaviour
{
    public AudioSource ads;
    public AudioClip ac;
    private bool play;
    // Start is called before the first frame update
    void Start()
    {
        ads.clip = ac;
    }

    // Update is called once per frame
    void Update()
    {
      if(play && !ads.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ads.Play();
            play = true;
        }
    }
}
