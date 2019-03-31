using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButtonDoor : MonoBehaviour {
    public int numberOfButtons;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (numberOfButtons == 1)
        {
            if (btn1.isPressed)
            {
                openAnimation();
            }
        }
        else if (numberOfButtons == 2)
        {
            if (btn1.isPressed && btn2.isPressed)
            {
                openAnimation();
            }

        }
        else if (numberOfButtons == 3)
        {
            if (btn1.isPressed && btn2.isPressed && btn3.isPressed)
            {
                openAnimation();
            }
        }

        else if (numberOfButtons == 4) {
            if (btn1.isPressed && btn2.isPressed && btn3.isPressed && btn4.isPressed) {
                openAnimation();
            }
        }
	}

    void openAnimation() {
        this.gameObject.SetActive(false);
    }
}
