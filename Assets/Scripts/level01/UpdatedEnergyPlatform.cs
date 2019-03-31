using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedEnergyPlatform : MonoBehaviour

    
{
    public Vector3 startPos;
    public Vector3 endPos;
    public GameObject endPosObj;
    public bool wasHit;
    // Start is called before the first frame update
    void Start()
    {
    startPos = this.transform.position;
        endPos = endPosObj.transform.position;
        wasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wasHit) {
            this.transform.position = Vector3.Slerp(startPos, endPos, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnergyArrow")
        {
            if (!wasHit)
            {
                wasHit = true;
            }

        }
    }
}
