using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDoor : MonoBehaviour
{
    public GameObject statue1;
    public GameObject statue2;
    private StatuePuzzle pressed1;
    private StatuePuzzle pressed2;
    private Quaternion doorOpen;
    private Quaternion doorClosed;
    // Start is called before the first frame update
    void Start()
    {
        pressed1 = statue1.GetComponent<StatuePuzzle>();
        pressed2 = statue2.GetComponent<StatuePuzzle>();
        doorOpen = Quaternion.Euler(-90, 0, 0);
        doorClosed = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (pressed1.getisActivated() && pressed2.getisActivated()) {
            this.transform.rotation = Quaternion.Lerp(doorOpen, doorClosed, Time.deltaTime * 0.01f);
        }
    }
}
