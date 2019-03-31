using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject start;
    public GameObject End;
    public Vector3 newPosition;
    public string state;
    public float speed;
    public float repeat;

	// Use this for initialization
	void Start () {
        ChnageTarget();
        start.GetComponent<MeshRenderer>().enabled = false;
        End.GetComponent<MeshRenderer>().enabled = false;
     }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition, speed * Time.deltaTime);
	}

    void ChnageTarget() {
        if (state.Equals("Moving to Start"))
        {
            state = "Moving to End";
            newPosition = End.transform.position;
        }

        else if (state.Equals("Moving to End"))
        {
            state = "Moving to Start";
            newPosition = start.transform.position;
        }
        else if (state.Equals("")) {
            state = "Moving to End";
            newPosition = End.transform.position;
        }
        Invoke("ChnageTarget", repeat);

    }
}
