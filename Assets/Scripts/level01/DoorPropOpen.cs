using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPropOpen : MonoBehaviour
{

    public Button btn1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (btn1.isPressed)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0,0,0), 5f);
        }
    }
}
