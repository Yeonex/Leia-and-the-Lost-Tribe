using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
 
    public PlayerHealth Player;
    public AudioSource ads;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        ads.clip = ac;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void zombieHit() {
        Player.TakeDamage(5);
        ads.Play();
    }


}
