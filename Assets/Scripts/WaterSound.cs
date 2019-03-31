using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour
{
    public IceBlock ice;
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
        if (ice.isBurnt || ice.isFrozen)
        {
            ads.Stop();
        }
        else if (!ads.isPlaying && !ice.isBurnt && !ice.isFrozen) {
            ads.Play();
        }
    }
}
