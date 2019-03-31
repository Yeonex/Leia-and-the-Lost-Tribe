using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCont : MonoBehaviour {

    public CharacterController characterController;
    public float getInputX;
    public float getInputZ;
    private Vector3 moveDir;
    private float moveSpeed;
    public float moveSpeedMultipler;
    public GameObject playerModel;
    public Transform pivot;
    public Animator animator;
    public float gravityScale = 3;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultipler = 2f;
    public float rotateSpeed = 2f;
    public float timeBeforeHardFall = 0f;
    private float fallingTime = 0f;
    private bool bowEpuiped;
    public GameObject bow;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public int secrectItem;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        bow.SetActive(false);
        effectToSpawn = vfx[0];
    }
	
	// Update is called once per frame
	void Update () {
        getInputX = Input.GetAxis("Horizontal");
        getInputZ = Input.GetAxis("Vertical");
        var getY = moveDir.y;
        var input = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        input.Normalize();
        if (Input.GetButton("Fire3"))
        {
            input *= 0.25f;
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }
        

        if (!characterController.isGrounded) {
            input *= 0.05f;
        }
        moveDir += input * Time.deltaTime;
        // moveDir.Normalize();
        // moveDir = moveDir * moveSpeedMultipler;
        
        moveDir.y = getY;
        if (characterController.isGrounded)
        {
            moveDir *= 0.75f;
            moveDir.y = Physics.gravity.y * fallMultiplier * Time.deltaTime * Time.deltaTime;
            if (Input.GetButtonDown("Jump") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                
                moveDir.y = jumpForce;
                animator.SetTrigger("HasJumpped");

                
            }

        }
        else {
            moveDir *= 0.99f;
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!bowEpuiped)
            {
                animator.SetTrigger("BowArmed");
                bow.SetActive(true);
                bowEpuiped = true;
                
            }
            else {
                animator.SetTrigger("BowDisarmed");
                bow.SetActive(false);
                bowEpuiped = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && bowEpuiped && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Player Idle")) {
            animator.SetTrigger("BowShoot");

            GameObject projectile = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);   
        }

        

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }









        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        moveDir.y = moveDir.y + (Physics.gravity.y * fallMultiplier * Time.deltaTime * Time.deltaTime);
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hard Land")) {
            moveDir *= 0F;
        }

        characterController.Move(moveDir* 2f);

    }

    public void giveSecrectPoint() {
        secrectItem += 1;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "SecrectItem") {
            if (Input.GetKey(KeyCode.E)){
                giveSecrectPoint();
                Debug.Log("Play sound");
                other.gameObject.SetActive(false);
            }
        }
    }

   
}
