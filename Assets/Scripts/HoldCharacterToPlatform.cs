using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacterToPlatform : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.parent = gameObject.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            other.transform.parent = null;
        }
            
    }
}
