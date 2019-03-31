using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera showcam;
    public Button btn;
    public float timer = 3;
    private bool showing;
    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        showing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (btn.isPressed && !triggered)
        {
            showing = true;
            showcam.gameObject.SetActive(true);
            triggered = true;
        }
        if (showing)
        {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0)
            {
                showing = false;
            }
        } else
        {
            showcam.gameObject.SetActive(false);
        }
    }

   
}
