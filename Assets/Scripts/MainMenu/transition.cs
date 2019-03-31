using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    public GameObject fade;
    private Animator animator;
    public GameObject vcam1;
    public GameObject Vcam2;
    public GameObject Vcam3;
    public GameObject Vcam4;
    public GameObject Vcam5;
    public GameObject canvas;
    public GameObject ControlMenu;
    public GameObject contrinueMenu;
    private bool cnrlMenu;
    private bool cntMenu;
    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        animator = fade.GetComponent<Animator>();
        fade.SetActive(true);
        vcam1.SetActive(true);
        Vcam2.SetActive(false);
        Vcam3.SetActive(false);
        Vcam4.SetActive(false);
        Vcam5.SetActive(false);
        ControlMenu.SetActive(false);
        contrinueMenu.SetActive(false);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.anyKey)
            {
                vcam1.SetActive(false);
                Vcam2.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            vcam1.SetActive(false);
            Vcam3.SetActive(false);
            Vcam4.SetActive(false);
            Vcam2.SetActive(true);
            ControlMenu.SetActive(false);
            contrinueMenu.SetActive(false);

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("fadeout") &&
             animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            fade.SetActive(false);
        }

   
    }

    public void newGame()
    {
        Debug.Log("New Game started!");
        vcam1.SetActive(false);
        Vcam2.SetActive(false);
        Vcam3.SetActive(false);
        Vcam4.SetActive(false);
        Vcam5.SetActive(true);
        fade.SetActive(true);
        animator.SetBool("fadein", true);

    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        vcam1.SetActive(false);
        Vcam2.SetActive(false);
        Vcam4.SetActive(false);
        Vcam3.SetActive(true);
        contrinueMenu.SetActive(true);

    }

    public void Control()
    {
        Debug.Log("Controls");
        vcam1.SetActive(false);
        Vcam2.SetActive(false);
        Vcam3.SetActive(false);
        Vcam4.SetActive(true);
        ControlMenu.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("exit");
    }

    public void ESC()
    {
        vcam1.SetActive(false);
        Vcam3.SetActive(false);
        Vcam4.SetActive(false);
        Vcam2.SetActive(true);
        ControlMenu.SetActive(false);
        contrinueMenu.SetActive(false);
      
    }


}
