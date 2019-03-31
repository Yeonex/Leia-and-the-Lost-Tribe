using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstpuzzle : MonoBehaviour
{
    public GameObject sprite;
    public bool stepped;
    private SpriteRenderer image;
    public Color color;
    public AudioSource ads;
    public AudioClip ac;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        ads.clip = ac;
        stepped = false;
        image = sprite.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stepped)
        {
            image.material.SetColor("_Color", Color.Lerp(image.material.GetColor("_Color"), color * 1.5f, 0.1f));      
        }
        if(!active && stepped)
        {
            ads.Play();
            active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (!stepped) {
                this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y - 0.1f), this.transform.position.z);
                stepped = true;
            }
            
            
        }
    }
}
