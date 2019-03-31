using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritGlowScript : MonoBehaviour
{
    [Header("Options")]
    public GameObject sprite;
    private SpriteRenderer image;
    public Color color;
    public float brightness = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        image = sprite.GetComponent<SpriteRenderer>();
        image.material.SetColor("_Color",  (color * brightness));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
