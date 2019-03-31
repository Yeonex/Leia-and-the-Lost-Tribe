using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnButtonPressed : MonoBehaviour
{
    public AudioSource ads;
    public AudioClip ac;
    public Button btn;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(btn.isPressed && !played)
        {
            ads.clip = ac;
            ads.Play();
            played = true;
        }
    }
}
