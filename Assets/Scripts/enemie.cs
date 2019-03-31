using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemie : MonoBehaviour {

    //Ice - 0 | Energy - 1 | Fire - 2 | Wind - 3 
    public int type;
    public int damage;
    public int MaxHP;
    public int CurrentHP;
    public int damagePlayer;
    public GameObject immuneText;
    public float hitTime;
    public float timeShown;
    private UpdatedPlayerController player;


    // Use this for initialization
    void Start () {
        CurrentHP = MaxHP;
        immuneText.SetActive(false);
        timeShown *= 1000;
        player = FindObjectOfType<UpdatedPlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((Time.time * 1000) - hitTime > timeShown)
        {
            immuneText.SetActive(false);

        }

        if(CurrentHP <= 0)
        {
            
            player.winCondition = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "IceArrow")
        {
            if (type == 2)
            {
                CurrentHP -= damage * 2;
            }
            else if (type == 0)
            {
                CurrentHP -= 0;
                showImmuneText();
            }
            else {
                CurrentHP -= damage;
            }
        }
        else if (collision.gameObject.tag == "FireArrow")
        {
            if (type == 0)
            {
                CurrentHP -= damage * 2;
            }
            else if (type == 2)
            {
                CurrentHP -= 0;
                showImmuneText();
            }
            else
            {
                CurrentHP -= damage;
            }
        }
        else if (collision.gameObject.tag == "EnergyArrow")
        {
            if (type == 4)
            {
                CurrentHP -= damage * 2;
            }
            else if (type == 2)
            {
                CurrentHP -= 0;
                showImmuneText();
            }
            else
            {
                CurrentHP -= damage;
            }
        }
        else if (collision.gameObject.tag == "WindArrow")
        {
            
            if (type == 1)
            {
                CurrentHP -= damage * 2;
            }
            else if (type == 3)
            {
                CurrentHP -= 0;
                showImmuneText();
            }
            else
            {
                CurrentHP -= damage;
            }
        }
        else if (collision.gameObject.tag == "Player") {
            Debug.Log("player hit");
            //  collision.GetComponent<PlayerHealth>().TakeDamage(damagePlayer);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damagePlayer);
        }
    }

    private void showImmuneText()
    {
        hitTime = Time.time * 1000;
        immuneText.SetActive(true);
    }

   
}
