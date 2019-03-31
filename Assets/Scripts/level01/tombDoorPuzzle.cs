using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombDoorPuzzle : MonoBehaviour
{
    private Quaternion doorOpen;
    private Quaternion doorClosed;
    public bool open;
    public bool closing;
    // Start is called before the first frame update
    void Start()
    {
        doorClosed = this.transform.rotation;
        doorOpen = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            this.transform.rotation = Quaternion.Lerp(doorOpen, doorClosed, Time.deltaTime * 6f);
            open = false;
        }

        if (closing)
        {
            this.transform.rotation = Quaternion.Lerp(doorClosed, doorOpen, Time.deltaTime * 6f);
            closing = false;
            open = false;
        }
    }
}
