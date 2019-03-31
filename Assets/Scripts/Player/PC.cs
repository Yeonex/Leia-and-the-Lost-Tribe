using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PC : MonoBehaviour
{

    public CharacterController characterController;
    public float getInputX;
    public float getInputZ;
    private Vector3 moveDir;
    private float moveSpeed;
    public float moveSpeedMultipler;
    public GameObject playerModel;
    public Transform pivot;
    public Animator animator;
    public float jumpForce;
    public float rotateSpeed = 2f;
    private bool bowEpuiped;
    public GameObject bow;
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public int secrectItem;
    public Text secrectItemUIText;
    public int bowState = 0;
    public Text selectedBowUIText;
    public AudioSource audioSource;
    public AudioClip EqBow1;
    public AudioClip UnBow1;
    public AudioClip fireBow;
    public bool jumpped;
    public GameObject bowOnBack;
    public Image crosshair;
    public float shootCD = 2f;
    private bool bowCD = false;
    private float cdTimer;
    public float knockbackForce;
    private bool knockedBack = false;
    public float kbTimer;
    private float kbTimerOriginal;
    private PlayerHealth playerHP;
    public bool winCondition;
    private float startTime;
    public Text timeTakenToFinish;




    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        bow.SetActive(false);
        effectToSpawn = vfx[0];
        crosshair.gameObject.SetActive(false);
        kbTimerOriginal = kbTimer;
        playerHP = GetComponent<PlayerHealth>();
        startTime = Time.time;
        timeTakenToFinish.text = "";
    }

    void FixedUpdate()
    {

        if (characterController.isGrounded)
        {
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                moveDir = Vector3.zero;
            }
            moveDir.y = Physics.gravity.y * Time.fixedDeltaTime * Time.fixedDeltaTime;
            if (jumpped)
            {
                moveDir.y = jumpForce;
                jumpped = false;
            }

        }
        else
        {
            moveDir *= 0.99f;


        }
        moveDir.y = moveDir.y + (Physics.gravity.y * Time.fixedDeltaTime * Time.fixedDeltaTime);

        characterController.Move(moveDir * 2f);
        animator.SetFloat("verSpeed", moveDir.y);

    }


    // Update is called once per frame
    void Update()
    {
        if (winCondition)
        {
            Debug.Log("Finished game");
            timeTakenToFinish.text = "Well done for winning the game! It took you " + ((Time.time - startTime)) + " seconds.";
            winCondition = false;
        }
        if (!knockedBack)
        {
            var input = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
            // input.Normalize();
            if (Input.GetButton("Fire1"))
            {
                input *= 1.25f;
                animator.SetBool("isWalking", true);
                animator.speed = 1f;
            }
            else if (Input.GetButton("Fire3"))
            {
                input *= 7.4f;
                animator.speed = 1.25f;
                animator.SetBool("isWalking", false);
            }
            else if (Input.GetMouseButton(1) && bowEpuiped)
            {
                input *= 1.25f;
                animator.SetBool("isWalking", false);
                animator.speed = 1f;
            }
            else
            {
                input *= 3.49f;
                animator.SetBool("isWalking", false);
                animator.speed = 1f;
            }


            if (!characterController.isGrounded)
            {
                input *= 1f;
            }

            Vector3 temp = moveDir;
            temp.Scale(Vector3.up);
            moveDir = input * 0.008f + temp;

        }
        else
        {
            kbTimer -= Time.deltaTime;
            if (kbTimer < 0)
            {
                knockedBack = false;
                kbTimer = kbTimerOriginal;
            }
        }



        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {

                //  moveDir.y = jumpForce;
                jumpped = true;
                animator.SetTrigger("HasJumpped");

            }

        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!bowEpuiped)
            {
                animator.SetTrigger("BowArmed");
                bow.SetActive(true);
                bowOnBack.SetActive(false);
                bowEpuiped = true;
                audioSource.clip = EqBow1;
                audioSource.Play();
                moveDir *= 0f;

            }
            else
            {
                animator.SetTrigger("BowDisarmed");
                bow.SetActive(false);
                bowOnBack.SetActive(true);
                bowEpuiped = false;
                audioSource.clip = UnBow1;
                audioSource.Play();


            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bowState = 0;
            selectedBowUIText.text = "Ice";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bowState = 1;
            selectedBowUIText.text = "Energy";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bowState = 2;
            selectedBowUIText.text = "Fire";

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bowState = 3;
            selectedBowUIText.text = "Wind";
        }

        if (Input.GetMouseButton(1) && bowEpuiped && (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walking bow")
            || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Bow out")
            || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Player Idle")
            || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Player Run")
            || this.animator.GetCurrentAnimatorStateInfo(0).IsName("shoot")))
        {
            crosshair.gameObject.SetActive(true);
            Vector3 aimPos = Camera.main.transform.position + Camera.main.transform.forward * 100;
            this.transform.eulerAngles = new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f);
            animator.SetBool("bowShootMode", true);
            if (Input.GetMouseButtonDown(0))
            {
                if (!bowCD)
                {
                    animator.SetTrigger("BowShoot");

                    //Ice - 0 | Energy - 1 | Fire - 2 | Wind - 3 
                    RaycastHit raycast;
                    Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycast, 100);
                    if (raycast.point == Vector3.zero)
                    {
                        GameObject arrow = Instantiate(vfx[bowState], firePoint.transform.position, Quaternion.LookRotation(aimPos - firePoint.transform.position));
                    }
                    else
                    {
                        GameObject arrow = Instantiate(vfx[bowState], firePoint.transform.position, Quaternion.LookRotation(raycast.point - firePoint.transform.position));
                    }

                    audioSource.clip = fireBow;
                    //audioSource.PlayDelayed(0.7f);
                    cdTimer = Time.time * 1000f;
                    bowCD = true;
                }
                else
                {
                    if ((Time.time * 1000) - cdTimer > shootCD)
                    {
                        bowCD = false;
                    }
                }



            }

        }
        else
        {
            crosshair.gameObject.SetActive(false);
            animator.SetBool("bowShootMode", false);
        }



        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && Movableanimation())
        {

            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }
        if (Input.GetMouseButton(1) && Movableanimation())
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);

            playerModel.transform.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z));
        }


        animator.SetBool("isGrounded", characterController.isGrounded);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hard Land")
          || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Death")
          || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Lifting")
          || this.animator.GetCurrentAnimatorStateInfo(0).IsName("BowArmed")
          || this.animator.GetCurrentAnimatorStateInfo(0).IsName("BowDisarmed")
          )
        {
            moveDir *= 0F;
        }




    }

    public void giveSecrectPoint()
    {
        secrectItem += 1;
        secrectItemUIText.text = secrectItem + "";
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "SecrectItem")
        {
            if (Input.GetKey(KeyCode.E))
            {
                giveSecrectPoint();
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy Projectile")
        {
            playerHP.TakeDamage(25);
        }
    }

    bool Movableanimation()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hard Land") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Death") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Lifting"))
        {
            return false;
        }
        return true;
    }

    public void knockback(Vector3 dir)
    {

        moveDir = dir * knockbackForce;
        knockedBack = true;
    }
}

