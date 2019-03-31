using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;
    public CharacterController characterController;
    public float gravityScale;

    private Vector3 moveDir;

    public Animator animator;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;
    public float turnSpeed = 0.5f;
    public Camera cam;

    public Vector3 hitNormal;
    public float slopeLimit = 45f;
    public float slideFriction = 0.3f;

    public Text scecretCounter;
    

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        //moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDir.y;
        moveDir = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDir = moveDir.normalized * moveSpeed;
        moveDir.y = yStore;

        if (characterController.isGrounded)
        {
            moveDir.y = Physics.gravity.y * gravityScale * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {

                Debug.Log("JumpForce no cntrl" + jumpForce);
                if (Input.GetButton("Fire1"))
                {
                    moveDir.y = jumpForce + (jumpForce / 6);
                    Debug.Log("JumpForce with cntrl" + jumpForce);
                }
                else
                {
                    moveDir.y = jumpForce;
                }

            }
        }
        if (Vector3.Angle(Vector3.up, hitNormal) >= slopeLimit) {
            moveDir.x += (1f - hitNormal.y) * hitNormal.x * (1f - slideFriction);
            moveDir.z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction);
        }

        moveDir.y = moveDir.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDir * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }


        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        Debug.DrawRay(this.transform.position, Vector3.down, Color.red);

	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }



}
