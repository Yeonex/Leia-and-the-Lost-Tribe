using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCameraController : MonoBehaviour {

    public float distanceAway;// how far the cam should be away
    public float distanceUp; // how high can the cam go
    public float camFollowingSmoothing; // delay of the camera movment and reaction
    private Transform target; //target object we are looking at
    private Vector3 lookDir;
    private Vector3 targetPosition;
    public Vector3 offset = new Vector3(0f, 1.5f, 0f);
    public Vector3 camSpeedDampner = new Vector3(0f, 0f, 0f);
    public float camSmoothingdamperTime = 0.1f;


	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform; //finding the game Object that is tided to our char
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 charOffset = target.position + offset;
        lookDir = charOffset - this.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        targetPosition = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
        targetPosition = charOffset + target.up * distanceUp - lookDir * distanceAway;
        smoothPosition(this.transform.position, targetPosition);
      //  transform.LookAt(target);
	}

    private void smoothPosition(Vector3 fromPos, Vector3 toPos) {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref camSpeedDampner, camSmoothingdamperTime);
    }
}
