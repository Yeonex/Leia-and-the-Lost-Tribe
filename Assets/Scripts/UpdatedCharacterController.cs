using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCharacterController : MonoBehaviour {

    public float getInputX;
    public float getInputZ;
    public Vector3 wantedMoveDir;
    public bool blockRotationPlayer;
    public float wantedRotationSpeed;
    public Animator anime;
    public float speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController charcontrl;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;
   


    // Use this for initialization
    void Start () {
        anime = this.GetComponentInChildren<Animator>();
        cam = Camera.main;
        charcontrl = this.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        inputMagnitude();
        isGrounded = charcontrl.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else {
            verticalVel -= 2;
        }

       // moveVector = new Vector3(0, verticalVel, 0);
       // charcontrl.Move(moveVector);
	}

    void playerMoveAndRotation() {
        getInputX = Input.GetAxis("Horizontal");
        getInputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = camera.transform.forward;
        var right = camera.transform.right; 

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        wantedMoveDir = forward * getInputZ + right * getInputX;

        if (!blockRotationPlayer) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wantedMoveDir), wantedRotationSpeed);
            charcontrl.Move(wantedMoveDir * Time.deltaTime);
        }
        

    }

    void inputMagnitude() {
        getInputX = Input.GetAxis("Horizontal");
        getInputZ = Input.GetAxis("Vertical");

        anime.SetFloat("InputZ", getInputZ, 0.03f, Time.deltaTime * 2f);
        anime.SetFloat("InputX", getInputX, 0.03f, Time.deltaTime * 2f);

        speed = new Vector2(getInputZ, getInputX).sqrMagnitude;

        if (speed > allowPlayerRotation)
        {
            anime.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
            playerMoveAndRotation();
        }
        else if (speed < allowPlayerRotation) {
            anime.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
        }

    }
}
