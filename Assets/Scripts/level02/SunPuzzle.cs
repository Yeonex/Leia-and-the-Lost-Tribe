using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPuzzle : MonoBehaviour
{

    public bool complete;
    public Light spot;
    public Light point;
    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        spot.gameObject.SetActive(false);
        point.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SunPuzzle" || other.gameObject.tag == "PushableObject")
        {
            complete = true;
            spot.gameObject.SetActive(true);
            point.gameObject.SetActive(true);
        }
    }
}
